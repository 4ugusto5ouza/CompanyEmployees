using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Service.DataTransferObjects.Employees
{
    public abstract record EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name field is 30 characters.")]
        public string? Name { get; init; }

        [Range(18, int.MaxValue, ErrorMessage = "Age is a required field and it can`t be lower than 18 years.")]
        public int Age { get; init; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the position field is 20 characters.")]
        public string? Position { get; init; }
    }
}
