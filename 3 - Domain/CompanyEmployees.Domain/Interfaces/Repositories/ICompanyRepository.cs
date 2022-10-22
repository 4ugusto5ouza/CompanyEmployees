using CompanyEmployees.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployees.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);
        void CreateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
