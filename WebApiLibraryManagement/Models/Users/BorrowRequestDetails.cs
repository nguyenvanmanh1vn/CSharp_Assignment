using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibraryManagement.Models
{
    public class BorrowRequestDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [Required]
        public int BorrowRequestId { get; set; }
        public virtual BorrowRequest BorrowRequest { get; set; }
    }
}