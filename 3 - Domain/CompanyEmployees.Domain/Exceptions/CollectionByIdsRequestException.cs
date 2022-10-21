using CompanyEmployees.Domain.Exceptions.ExceptionsBase;

namespace CompanyEmployees.Domain.Exceptions
{
    public sealed class CollectionByIdsRequestException : BadRequestException
    {
        public CollectionByIdsRequestException() : base("Collection count mismatch comparing to ids.")
        {
        }
    }
}
