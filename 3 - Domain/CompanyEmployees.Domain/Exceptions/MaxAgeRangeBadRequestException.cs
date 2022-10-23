using CompanyEmployees.Domain.Exceptions.ExceptionsBase;

namespace CompanyEmployees.Domain.Exceptions
{
    public class MaxAgeRangeBadRequestException : BadRequestException
    {
        public MaxAgeRangeBadRequestException() : base("Mas age can`t be less than min age.")
        {
        }
    }
}
