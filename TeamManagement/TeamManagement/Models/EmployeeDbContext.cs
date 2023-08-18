using System.Data.Entity;

namespace TeamManagement.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}