using CompanyEmployees.Service.DataTransferObjects.Users;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CompanyEmployees.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
