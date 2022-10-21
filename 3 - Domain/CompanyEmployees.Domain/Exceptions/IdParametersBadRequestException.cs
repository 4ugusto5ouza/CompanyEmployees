using CompanyEmployees.Domain.Exceptions.ExceptionsBase;

namespace CompanyEmployees.Domain.Exceptions
{
    public sealed class IdParametersBadRequestException : BadRequestException
    {
        public IdParametersBadRequestException() : base("Parameters ids is null")
        {
        }
    }
}
