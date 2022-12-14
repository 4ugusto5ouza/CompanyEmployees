using CompanyEmployees.Domain.Exceptions.ExceptionsBase;
using System;

namespace CompanyEmployees.Domain.Exceptions
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(Guid employeeId)
            :base($"The employee with id: {employeeId} doesn`t exist in the database.")
        {
        }
    }
}
