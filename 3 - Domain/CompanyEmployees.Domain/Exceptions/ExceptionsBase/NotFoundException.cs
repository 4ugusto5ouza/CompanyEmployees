using System;

namespace CompanyEmployees.Domain.Exceptions.ExceptionsBase
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message)
            : base(message) { }
    }
}
