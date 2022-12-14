using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.RequestFeatures;
using CompanyEmployees.Domain.RequestFeatures.Parameters;
using System;
using System.Threading.Tasks;

namespace CompanyEmployees.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,EmployeeParameters employeeParameters, bool trackChanges);
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
