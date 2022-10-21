using System;

namespace CompanyEmployees.Service.DataTransferObjects.Employees
{
    public record class EmployeeDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public int Age { get; init; }
        public string? Position { get; init; }
    }
}
