namespace AspNetMvcTagHelpersApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
