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
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public List<BorrowingRequest> BorrowingRequests {get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}