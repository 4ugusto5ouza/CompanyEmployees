using CompanyEmployees.Service.DataTransferObjects.Users;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CompanyEmployees.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
    }
}
