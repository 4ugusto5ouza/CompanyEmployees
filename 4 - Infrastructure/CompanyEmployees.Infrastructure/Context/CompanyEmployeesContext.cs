using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Infrastructure.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Infrastructure.Context
{
    public class CompanyEmployeesContext : IdentityDbContext<User>
    {
        public CompanyEmployeesContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration()); 
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        DbSet<Company>? Companies { get; set; }
        DbSet<Employee>? Employees { get; set; }
    }
}
