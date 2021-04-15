using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibraryManagement.Models
{
    public class BorrowingRequestDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required]
        public int BorrowingRequestId { get; set; }
        public BorrowingRequest BorrowingRequest { get; set; }
    }
}