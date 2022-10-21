using System;

namespace CompanyEmployees.Domain.Exceptions.ExceptionsBase
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message)
            : base(message)
        {
        }
    }
}
