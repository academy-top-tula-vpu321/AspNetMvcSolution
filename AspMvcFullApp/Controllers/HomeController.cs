using AspMvcFullApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspMvcFullApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext context;

        public HomeController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await context.Employees.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id is not null)
            {
                Employee? employee = await context.Employees.FindAsync(id);
                if(employee is not null)
                    return View(employee);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id is not null)
            {
                //Employee? employee = await context.Employees.FindAsync(id);
                //if(employee is not null)
                //{
                //    context.Employees.Remove(employee);
                //    await context.SaveChangesAsync();
                //    return RedirectToAction("Index");
                //}

                Employee employee = new() { Id = id.Value };
                context.Entry(employee).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
