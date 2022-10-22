using CompanyEmployees.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace CompanyEmployees.Domain.Interfaces
{
    public interface IRepositoryManager
    {
        ICompanyRepository CompanyRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }

        Task SaveAsync();
    }
}
