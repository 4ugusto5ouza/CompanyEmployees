using CompanyEmployees.Service.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace CompanyEmployees.Service.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto GetCompany(Guid companyId, bool trackChanges);

    }
}
