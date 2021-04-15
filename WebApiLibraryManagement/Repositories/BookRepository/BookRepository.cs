using WebApiLibraryManagement.Models.FluentAPI.Relationships.Required;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiLibraryManagement.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetAllInclude()
        {
            return Entities
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsEnumerable();
        }

        public Book GetBookById(int id) => Entities.FirstOrDefault(b => b.Id == id);
    }
}
