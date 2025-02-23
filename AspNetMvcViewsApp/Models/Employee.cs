using System.ComponentModel.DataAnnotations;

namespace AspNetMvcViewsApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Company? Company { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Company: {Company?.Title}";
        }
    }
}
