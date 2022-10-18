using CompanyEmployees.Domain.Interfaces.Repositories;

namespace CompanyEmployees.Domain.Interfaces
{
    public interface IRepositoryManager
    {
        ICompanyRepository CompanyRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }

        void Save();
    }
}
