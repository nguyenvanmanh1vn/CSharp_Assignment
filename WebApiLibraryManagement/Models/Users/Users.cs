using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WebApiLibraryManagement.Models
{

    public class User : Person
    {
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        [Required]
        public string Phone { get; set; }
        public int Age { get; set; }


        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public string Avatar { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string Address { get; set; }

        public virtual List<BorrowRequest> BorrowRequests { get; set; }
        [Required]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}