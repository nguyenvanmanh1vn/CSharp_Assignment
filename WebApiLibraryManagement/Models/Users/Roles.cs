using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibraryManagement.Models
{
    public enum RoleName{
        Admin,
        User
    }
    public class Role
    {
        [Key]
        public int Id{get;set;}

        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public RoleName RoleName{get;set;}

        [Required]
        [Column(TypeName = "text")]
        public string RoleDescription{get;set;}
        public List<User> Users { get; set; }
    }
}