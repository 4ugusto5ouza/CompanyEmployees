using System.Collections.Generic;
using CompanyEmployees.Service.DataTransferObjects.Employees;

namespace CompanyEmployees.Service.DataTransferObjects.Companies
{
    public record CompanyForCreationDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);
}
