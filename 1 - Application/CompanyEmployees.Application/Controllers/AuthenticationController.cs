using CompanyEmployees.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Application.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }
    }
}
