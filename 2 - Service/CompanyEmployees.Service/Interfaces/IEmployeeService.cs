using CompanyEmployees.Domain.RequestFeatures;
using CompanyEmployees.Domain.RequestFeatures.Parameters;
using CompanyEmployees.Service.DataTransferObjects.Employees;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployees.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<(IEnumerable<EmployeeDto> employees , MetaData metaData)> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);
        Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
        Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);
        Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);
        Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);
    }
}
