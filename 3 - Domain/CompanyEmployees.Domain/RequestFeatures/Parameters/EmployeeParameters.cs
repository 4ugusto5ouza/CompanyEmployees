namespace CompanyEmployees.Domain.RequestFeatures.Parameters
{
    public class EmployeeParameters : RequestParameters
    {
        public uint MinAge { get; set; }
        public uint MaxAge { get; set; } = int.MaxValue;
        public bool ValidAgeRange => MaxAge > MinAge;

        public string SearchName { get; set; }
    }
}
