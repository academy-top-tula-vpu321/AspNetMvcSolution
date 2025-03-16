using AspNetMvcHelpersApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Diagnostics;

namespace AspNetMvcHelpersApp.Controllers
{
    public class HomeController : Controller
    {
        List<string> countries = new() { "Russia", "China", "France" };
        List<string> cities = new() { "Moscow", "Voroneg", "Tula", "St. Peterburg" };
        public IActionResult Index()
        {
            ViewData["countries"] = countries;
            ViewData["cities"] = cities;

            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            List<Country> countries = new List<Country>()
            {
                new(){ Id = 1, Title = "Russia" },
                new(){ Id = 2, Title = "China" },
                new(){ Id = 3, Title = "Usa" },
            };
            ViewData["countries"] = new SelectList(countries, "Id", "Title");
            return View();
        }

        [HttpPost]
        public string Privacy(Employee employee)
        {
            

            return $"{employee.Name} {employee.BirthDate.ToShortDateString()}";
        }

    }
}
