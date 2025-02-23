namespace AspNetMvcViewsApp.Models
{
    public class EmployeeViewModel
    {
        public string Title { get; set; } = string.Empty;
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
