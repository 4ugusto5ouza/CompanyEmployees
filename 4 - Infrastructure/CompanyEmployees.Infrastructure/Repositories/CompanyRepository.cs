using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.Interfaces.Repositories;
using CompanyEmployees.Infrastructure.Context;
using CompanyEmployees.Infrastructure.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyEmployeesContext companyEmployeesContext)
            : base(companyEmployeesContext)
        {
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                    .OrderBy(c => c.Name)
                    .ToListAsync();
        }
        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges)
        {
            return  await FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateCompany(Company company) => Create(company);


        public void DeleteCompany(Company company)
        {
            Delete(company);
        }
    }
}
