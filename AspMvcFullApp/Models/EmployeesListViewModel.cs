using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspMvcFullApp.Models
{
    public class EmployeesListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
        public SelectList Companies { get; set; } = new(new List<Company>(), "Id", "Title");
        public string Name { get; set; }
    }
}
