using AutoMapper;
using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.Exceptions;
using CompanyEmployees.Domain.Interfaces;
using CompanyEmployees.Service.DataTransferObjects.Companies;
using CompanyEmployees.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Service.Services
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        private async Task<Company> GetCompanyAndCheckIfItExist(Guid id, bool trackChanges)
        {
            var company = await _repository.CompanyRepository.GetCompanyAsync(id, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(id);

            return company;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
        {
            var companies = await _repository.CompanyRepository.GetAllCompaniesAsync(trackChanges);

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDto;
        }

        public async Task<CompanyDto> GetCompanyAsync(Guid id, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExist(id, trackChanges);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var companyEntities = await _repository.CompanyRepository.GetByIdsAsync(ids, trackChanges);

            if (ids.Count() != companyEntities.Count())
                throw new CollectionByIdsRequestException();

            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

            return companiesToReturn;
        }

        public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);

            _repository.CompanyRepository.CreateCompany(companyEntity);
            await _repository.SaveAsync();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyToReturn;
        }

        public async Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequestException();

            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);

            foreach (var company in companyEntities)
            {
                _repository.CompanyRepository.CreateCompany(company);
            }

            await _repository.SaveAsync();

            var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

            return (companyCollectionToReturn, ids);
        }

        public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
        {
            var companyEntity = await GetCompanyAndCheckIfItExist(companyId, trackChanges);

            _mapper.Map(companyForUpdate, companyEntity);

            await _repository.SaveAsync();
        }

        public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
        {
            var company = await GetCompanyAndCheckIfItExist(companyId, trackChanges);

            _repository.CompanyRepository.DeleteCompany(company);
            await _repository.SaveAsync();
        }
    }
}