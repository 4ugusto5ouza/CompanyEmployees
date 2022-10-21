using CompanyEmployees.Service.DataTransferObjects.Companies;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Service.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        CompanyDto GetCompany(Guid companyId, bool trackChanges);
        CompanyDto CreateCompany(CompanyForCreationDto company);
        void UpdateCompany(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
        (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection);
        void DeleteCompany(Guid companyId, bool trackChanges);
    }
}
