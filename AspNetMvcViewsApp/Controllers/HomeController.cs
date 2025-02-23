using AspNetMvcViewsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetMvcViewsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Name"] = "Bobby";
            ViewData["Age"] = 29;

            List<string> cities = new List<string>()
            {
                "Moscow", "Kaluga", "Tula", "St Peterburg"
            };

            ViewData["Cities"] = cities;

            ViewBag.Message = "Hello world";
            ViewBag.Cities = cities;

            return View("MyPrivacy");
        }

        public IActionResult Employees()
        {
            List<Company> companies = new List<Company>()
            {
                new(){ Id = 1, Title = "Yandex" },
                new(){ Id = 2, Title = "Ozon" },
                new(){ Id = 3, Title = "Mail Group" },
            };

            List<Employee> employees = new List<Employee>()
            {
                new(){ Id = 1, Name = "Bobby", Company = companies[0] },
                new(){ Id = 2, Name = "Jonny", Company = companies[1] },
                new(){ Id = 3, Name = "Sammy", Company = companies[0] },
                new(){ Id = 4, Name = "Poppy", Company = companies[2] },
                new(){ Id = 5, Name = "Kenny", Company = companies[1] },
            };

            EmployeeViewModel viewModel = new EmployeeViewModel();
            viewModel.Employees = employees;
            viewModel.Title = "Employees List";

            return View(employees);
        }

    }
}
