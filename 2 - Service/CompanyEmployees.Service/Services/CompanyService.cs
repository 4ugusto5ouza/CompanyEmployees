using CompanyEmployees.Domain.Interfaces;
using CompanyEmployees.Service.DataTransferObjects;
using CompanyEmployees.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyEmployees.Service.Services
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.CompanyRepository.GetAllCompanies(trackChanges);

                var companiesDto = companies.Select(c => new CompanyDto(c.Id, c.Name ?? "", string.Join(" ", c.Address, c.Country))).ToList();

                return companiesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");
                throw;
            }
        }
    }
}
