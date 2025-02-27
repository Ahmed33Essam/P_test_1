using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace P_test_1.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ITIContext():base()
        {

        }
        public ITIContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AHMED33;Initial Catalog=P_test_1;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
    