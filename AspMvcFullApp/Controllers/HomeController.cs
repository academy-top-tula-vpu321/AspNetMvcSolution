using AspMvcFullApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        public async Task<IActionResult> Index(SortState sortState = SortState.NameAsc)
        {
            IQueryable<Employee> employees = context.Employees
                                   .Include(e => e.Company);

            ViewData["NameSort"] = (sortState == SortState.NameAsc) ? SortState.NameDesc : SortState.NameAsc;
            ViewData["AgeSort"] = (sortState == SortState.AgeAsc) ? SortState.AgeDesc : SortState.AgeAsc;
            ViewData["CompanySort"] = (sortState == SortState.CompanyAsc) ? SortState.CompanyDesc : SortState.CompanyAsc;

            employees = sortState switch
            {
                SortState.NameDesc => employees.OrderByDescending(e => e.Name),
                SortState.AgeAsc => employees.OrderBy(e => e.Age),
                SortState.AgeDesc => employees.OrderByDescending(e => e.Age),
                SortState.CompanyAsc => employees.OrderBy(e => e.Company!.Title),
                SortState.CompanyDesc => employees.OrderByDescending(e => e.Company!.Title),
                _ => employees.OrderBy(e => e.Name)
            };

            return View(await employees.ToListAsync());

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Companies"] = context.Companies;
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
                ViewData["Companies"] = context.Companies;
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
