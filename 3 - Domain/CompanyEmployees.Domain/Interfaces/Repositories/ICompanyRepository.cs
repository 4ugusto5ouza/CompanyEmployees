using CompanyEmployees.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
        Company GetCompany(Guid companyId, bool trackChanges);
    }
}
