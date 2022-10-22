using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyEmployees.Service.DataTransferObjects.Employees;

namespace CompanyEmployees.Service.DataTransferObjects.Companies
{
    public record CompanyForCreationDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum lenght for the Name is 60 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum lenght for the Address is 60 characters.")]
        public string? Address { get; init; }

        public string? Country { get; init; }
        public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
    }
}
