using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiLibraryManagement.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        // Eager Loading of Related Data
        public IEnumerable<Book> GetAllInclude()
        {
            return Entities
                .Include(book => book.Author)
                .Include(book => book.Category)
                .ToList();
        }
        public IEnumerable<Book> GetListBookByCategoryId(int categoryId)
        {
            return Entities.Where(b => b.CategoryId == categoryId).ToList();
        }
    }
}
