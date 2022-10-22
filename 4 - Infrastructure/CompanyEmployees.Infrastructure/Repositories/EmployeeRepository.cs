using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.Interfaces.Repositories;
using CompanyEmployees.Infrastructure.Context;
using CompanyEmployees.Infrastructure.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyEmployeesContext companyEmployeesContext)
            : base(companyEmployeesContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges)
        {
            return await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                        .OrderBy(e => e.Name)
                        .ToListAsync();
        }
        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}
