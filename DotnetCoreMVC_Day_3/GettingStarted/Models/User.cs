using System.ComponentModel.DataAnnotations;


namespace GettingStarted.Models
{
    public class User
    {
        public int UserId{get;set;}
        [Required]
        public string UserName{get;set;}
        [Required]
        public string Password{get;set;}
        public int RoleId{get;set;}

    }
    public class Role
    {
        public int RoleId{get;set;}
        public string RoleName{get;set;}
    }

}