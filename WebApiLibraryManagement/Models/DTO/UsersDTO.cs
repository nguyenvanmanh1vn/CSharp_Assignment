using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApiLibraryManagement.Models
{
    public class FormUserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class FormUserRegister
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        [StringLength(50)]
        [Required]
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile Avatar { get; set; }
        public string Address { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}