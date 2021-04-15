using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibraryManagement.Models
{
    public class Book:BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<BorrowingRequestDetail> BorrowingRequestDetails {get; set; }
    }
}
