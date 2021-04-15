using System.ComponentModel.DataAnnotations;

namespace WebApiLibraryManagement.Models
{
    public class UpdateBook
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }

        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
