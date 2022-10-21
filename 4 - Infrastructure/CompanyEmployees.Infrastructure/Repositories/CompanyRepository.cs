using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.Interfaces.Repositories;
using CompanyEmployees.Infrastructure.Context;
using CompanyEmployees.Infrastructure.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyEmployees.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyEmployeesContext companyEmployeesContext)
            : base(companyEmployeesContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .OrderBy(c => c.Name)
                    .ToList();
        }

        public Company GetCompany(Guid companyId, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
        }

        public void CreateCompany(Company company) => Create(company);

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            return FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
        }

        public void DeleteCompany(Company company)
        {
            Delete(company);
        }
    }
}
