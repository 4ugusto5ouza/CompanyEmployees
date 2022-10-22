using CompanyEmployees.Service.DataTransferObjects.Companies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployees.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);
        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges);
        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);
        Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection);
        Task DeleteCompanyAsync(Guid companyId, bool trackChanges);
    }
}
