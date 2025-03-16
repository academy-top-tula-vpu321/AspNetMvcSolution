using Microsoft.EntityFrameworkCore;

namespace AspMvcFullApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
