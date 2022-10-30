using AutoMapper;
using CompanyEmployees.Domain.ConfigurationModels;
using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.Interfaces;
using CompanyEmployees.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;

namespace CompanyEmployees.Service.Services.ServiceManager
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IOptions<JwtConfiguration> configuration)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }

        public ICompanyService Company => _companyService.Value;
        public IEmployeeService Employee => _employeeService.Value;
        public IAuthenticationService Authentication => _authenticationService.Value;
    }
}
