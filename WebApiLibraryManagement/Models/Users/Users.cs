using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibraryManagement.Models
{
    
    public class User : Person
    {
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        
        [StringLength(50)]
        [Required]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public List<BorrowingRequest> BorrowingRequests {get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string Address { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}