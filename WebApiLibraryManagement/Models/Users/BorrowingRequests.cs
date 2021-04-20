using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLibraryManagement.Models
{
    public class BorrowingRequest : BaseEntity
    {
        [Required]
        [FromQuery(Name = "userId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual List<BorrowingRequestDetail> BorrowingRequestDetails { get; set; }
    }
}