using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibraryManagement.Models
{
    public class Book : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<BorrowRequestDetail> BorrowRequestDetails { get; set; }
    }
}
