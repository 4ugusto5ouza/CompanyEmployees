using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployees.Domain.Entities
{
    public class Company
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Company name is a required field.")]
        [MaxLength(60, ErrorMessage ="Maximum lenght for the Name is 60 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum lenght for the Address is 60 characters.")]
        public string? Address { get; set; }

        public string? Country { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
