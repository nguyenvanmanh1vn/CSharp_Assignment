using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WebApiLibraryManagement.Models
{
    public enum Status
    {
        Approving = 1,
        Pending = 2,
        Rejecting = 3
    }
    public class BorrowingRequest : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public Status Status { get; set; }
        public virtual List<BorrowingRequestDetail> BorrowingRequestDetails { get; set; }
    }
}