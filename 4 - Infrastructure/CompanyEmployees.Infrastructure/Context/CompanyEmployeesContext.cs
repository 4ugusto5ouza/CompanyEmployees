using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Infrastructure.Context
{
    public class CompanyEmployeesContext : DbContext
    {
        public CompanyEmployeesContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.ApplyConfiguration(new CompanyConfiguration()); 
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        DbSet<Company>? Companies { get; set; }
        DbSet<Employee>? Employees { get; set; }
    }
}
