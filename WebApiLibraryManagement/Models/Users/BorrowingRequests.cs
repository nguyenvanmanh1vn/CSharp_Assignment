using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibraryManagement.Models
{
    public enum Status
    {
        Pending,
        Approving,
        Rejecting
    }
    public class BorrowingRequest : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public Status Status { get; set; }

        public List<BorrowingRequestDetail> BorrowingRequestDetails{get;set;}
    }
}