using CompanyEmployees.Service.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Service.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
    }
}
