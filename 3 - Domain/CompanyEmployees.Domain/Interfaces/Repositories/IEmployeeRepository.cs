using CompanyEmployees.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
    }
}
