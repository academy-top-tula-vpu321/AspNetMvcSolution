namespace AspNetMvcAdvansedApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public Company? Company { get; set; }
    }

    public class EmployeesViewModel
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Company> Companies { get; set; } = new();
        public int? EmployeeSelectedId { get; set; }
        public Employee? EmployeeSelected { get; set; } = null;
    }

    //public record EmployeeRec(int Id, string Name, int Age);
}
