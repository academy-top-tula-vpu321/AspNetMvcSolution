using AspNetMvcHelpersApp.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
