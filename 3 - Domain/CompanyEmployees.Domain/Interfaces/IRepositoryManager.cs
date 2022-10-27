using CompanyEmployees.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace CompanyEmployees.Domain.Interfaces
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }

        Task SaveAsync();
    }
}
