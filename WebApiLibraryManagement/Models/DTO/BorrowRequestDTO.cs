using System.ComponentModel.DataAnnotations;

namespace WebApiLibraryManagement.Models
{
    public class BorrowRequestDTO
    {
        [Required]
        public int UserId { get; set; }
        public string Status { get; set; }
        public string BorrowBooks { get; set; }
    }
}