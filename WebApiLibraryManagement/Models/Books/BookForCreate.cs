using System.ComponentModel.DataAnnotations;

namespace WebApiLibraryManagement.Models
{
    public class BookForCreate
    {
        [MaxLength(255)]
        public string Title { get; set; }

        [Range(1, long.MaxValue)]
        public int AuthorId { get; set; }

        [Range(1, long.MaxValue)]
        public int CategoryId { get; set; }
    }
}
