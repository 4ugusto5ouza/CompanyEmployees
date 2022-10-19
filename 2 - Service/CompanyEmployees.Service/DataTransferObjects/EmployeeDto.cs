using System;

namespace CompanyEmployees.Service.DataTransferObjects
{
    public record class EmployeeDto(Guid Id, string Name, int Age, string Position);
}
