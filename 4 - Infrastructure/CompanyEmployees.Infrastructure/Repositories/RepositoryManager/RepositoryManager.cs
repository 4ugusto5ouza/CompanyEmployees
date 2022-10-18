using CompanyEmployees.Domain.Interfaces;
using CompanyEmployees.Domain.Interfaces.Repositories;
using CompanyEmployees.Infrastructure.Context;
using System;

namespace CompanyEmployees.Infrastructure.Repositories.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CompanyEmployeesContext _companyEmployeesContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        public RepositoryManager(CompanyEmployeesContext companyEmployeesContext)
        {
            _companyEmployeesContext = companyEmployeesContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(companyEmployeesContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(companyEmployeesContext));
        }

        public ICompanyRepository CompanyRepository => _companyRepository.Value;
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public void Save()
        {
            _companyEmployeesContext.SaveChanges();
        }
    }
}
