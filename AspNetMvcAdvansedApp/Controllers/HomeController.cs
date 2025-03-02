using AspNetMvcAdvansedApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetMvcAdvansedApp.Controllers
{
    public class HomeController : Controller
    {
        EmployeesViewModel employeesViewModel = new EmployeesViewModel();
        List<Company> companies = new List<Company>();
        List<Employee> employees = new List<Employee>();

        public HomeController()
        {
            companies = new List<Company>()
            {
                new() { Id = 1, Title = "Yandex" },
                new() { Id = 2, Title = "Avito" },
                new() { Id = 3, Title = "SberBank" },
            };

            employees = new List<Employee>()
            {
                new (){ Id = 1, Name = "Bobby", Age = 29, Company = companies[0] },
                new (){ Id = 2, Name = "Sammy", Age = 32, Company = companies[1] },
                new (){ Id = 3, Name = "Jimmy", Age = 26, Company = companies[2] },
                new (){ Id = 4, Name = "Poppy", Age = 21, Company = companies[0] },
                new (){ Id = 5, Name = "Kenny", Age = 35, Company = companies[1] },
                new (){ Id = 6, Name = "Benny", Age = 42, Company = companies[0] },
            };
        }

        
        public IActionResult Index(int? companyId)
        {
            employeesViewModel.Companies = companies;
            employeesViewModel.Companies.Insert(0, new() { Id = 0, Title = "All companies" } );

            if (companyId is not null && companyId > 0)
                employeesViewModel.Employees = employees.Where(e => e.Company?.Id == companyId).ToList();
            else
                employeesViewModel.Employees = employees;

            //employeesViewModel.EmployeeSelectedId = 2;
            //employeesViewModel.EmployeeSelected
            //       = employeesViewModel.Employees
            //                           .FirstOrDefault(e => e.Id == employeesViewModel.EmployeeSelectedId);

            return View(employeesViewModel);
        }
    }
}
