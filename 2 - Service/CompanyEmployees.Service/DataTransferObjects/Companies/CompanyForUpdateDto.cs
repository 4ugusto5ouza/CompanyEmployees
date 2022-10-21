using CompanyEmployees.Service.DataTransferObjects.Employees;
using System.Collections.Generic;

namespace CompanyEmployees.Service.DataTransferObjects.Companies
{
    public record CompanyForUpdateDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);
}
