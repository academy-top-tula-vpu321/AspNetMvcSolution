using AspNetMvcTagHelpersApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace AspNetMvcTagHelpersApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //ViewData["Companies"] = new SelectList(companies, "Id", "Title");
            return View(new EmployeeViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }

    class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Company> Companies { get; set; }

        public EmployeeViewModel()
        {
            List<Company>  companies = new List<Company>()
            {
                new() { Id = 1, Title = "Yandex" },
                new() { Id = 2, Title = "Mail Group" },
                new() { Id = 3, Title = "Kaspersky" },
            };
        }

    }
}

