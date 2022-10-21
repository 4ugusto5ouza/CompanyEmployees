using CompanyEmployees.Domain.Exceptions.ExceptionsBase;

namespace CompanyEmployees.Domain.Exceptions
{
    public sealed class CompanyCollectionBadRequestException : BadRequestException
    {
        public CompanyCollectionBadRequestException() : base("Company collection send from a client is null.")
        {
        }
    }
}
