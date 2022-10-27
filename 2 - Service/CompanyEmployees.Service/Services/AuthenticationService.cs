using AutoMapper;
using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.Interfaces;
using CompanyEmployees.Service.DataTransferObjects.Users;
using CompanyEmployees.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CompanyEmployees.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            throw new System.NotImplementedException();
        }
    }
}
