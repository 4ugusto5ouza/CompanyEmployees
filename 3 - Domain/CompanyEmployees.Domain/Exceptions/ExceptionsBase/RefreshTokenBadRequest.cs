namespace CompanyEmployees.Domain.Exceptions.ExceptionsBase
{
    public class RefreshTokenBadRequest : BadRequestException
    {
        public RefreshTokenBadRequest() 
            : base("Invalid client request. The token has some invalid values.")
        {
        }
    }
}
