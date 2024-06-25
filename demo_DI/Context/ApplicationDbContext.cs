using demo_DI.Model;
using Microsoft.EntityFrameworkCore;

namespace demo_DI.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {}
        /// <summary>
        /// Entity for Triggers, Views and Func
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
