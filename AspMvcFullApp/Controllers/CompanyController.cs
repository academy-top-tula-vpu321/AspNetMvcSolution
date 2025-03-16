using AspMvcFullApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFullApp.Controllers
{
    public class CompanyController : Controller
    {
        ApplicationContext context;

        public CompanyController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await context.Companies.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            context.Companies.Add(company);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is not null)
            {
                Company? company = await context.Companies.FindAsync(id);
                if (company is not null)
                    return View(company);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Company company)
        {
            context.Companies.Update(company);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id is not null)
                {
                    Company company = new() { Id = id.Value };
                    context.Entry(company).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
