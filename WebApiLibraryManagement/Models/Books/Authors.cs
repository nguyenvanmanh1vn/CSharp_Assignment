using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibraryManagement.Models
{
    public class Author : Person
    {
        public List<Book> Books { get; set; }
    }
}
