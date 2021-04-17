using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibraryManagement.Models
{
    public enum RoleName
    {
        User = 0,
        Admin = 1
    }
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public RoleName RoleName { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string RoleDescription { get; set; }
        public virtual List<User> Users { get; set; }
    }
}