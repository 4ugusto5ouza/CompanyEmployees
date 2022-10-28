using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Service.DataTransferObjects.Users
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
