namespace CompanyEmployees.Service.Interfaces
{
    public interface IServiceManager
    {
        ICompanyService Company { get; }
        IEmployeeService Employee { get; }
        IAuthenticationService Authentication { get; }
    }
}
