using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApiLibraryManagement.Models
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name{get;set;}
        public virtual List<Book> Books { get; set; }
    }
}