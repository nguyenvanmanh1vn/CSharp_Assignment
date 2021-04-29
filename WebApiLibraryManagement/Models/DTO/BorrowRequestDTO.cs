using System.ComponentModel.DataAnnotations;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Models
{
    public class BorrowRequestDTO
    {
        [Required]
        public int UserId { get; set; }
        public string Status { get; set; }
        public BorrowRequest[] BorrowBooks { get; set; }
    }
}