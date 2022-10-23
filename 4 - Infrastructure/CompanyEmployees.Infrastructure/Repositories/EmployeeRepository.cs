using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.Interfaces.Repositories;
using CompanyEmployees.Domain.RequestFeatures;
using CompanyEmployees.Domain.RequestFeatures.Parameters;
using CompanyEmployees.Infrastructure.Context;
using CompanyEmployees.Infrastructure.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
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

        private IQueryable<Employee> GetEmployeesAsyncFilters(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            var queryableEmployees = FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges);

            queryableEmployees = queryableEmployees.Where(e => e.Age >= employeeParameters.MinAge && e.Age <= employeeParameters.MaxAge);

            if (!string.IsNullOrEmpty(employeeParameters.SearchName))
            {
                queryableEmployees = queryableEmployees.Where(e => e.Name.ToLower().Contains(employeeParameters.SearchName.ToLower()));
            }

            return queryableEmployees;
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employees = await GetEmployeesAsyncFilters(companyId, employeeParameters, trackChanges)
                                    .OrderBy(e => e.Name)
                                    .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
                                    .Take(employeeParameters.PageSize)
                                    .ToListAsync();

            var count = await GetEmployeesAsyncFilters(companyId, employeeParameters, trackChanges).CountAsync();

            return new PagedList<Employee>(employees, count, employeeParameters.PageNumber, employeeParameters.PageSize);
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
