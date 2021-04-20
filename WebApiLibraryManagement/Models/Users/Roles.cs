using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibraryManagement.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserRoles { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string RoleDescription { get; set; }
        public virtual List<User> Users { get; set; }
    }
}