using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Service.DataTransferObjects.Employees
{
    public record EmployeeForCreationDto//(string Name, int Age, string Position);
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name field is 30 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; init; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the position field is 20 characters.")]
        public string? Position { get; init; }
    }
}
