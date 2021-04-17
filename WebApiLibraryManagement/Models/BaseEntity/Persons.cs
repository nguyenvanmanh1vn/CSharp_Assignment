using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibraryManagement.Models
{
    public enum Gender
    {
        Female = 0,
        Male = 1
    }
    public class Person : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
        public string LastName { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
