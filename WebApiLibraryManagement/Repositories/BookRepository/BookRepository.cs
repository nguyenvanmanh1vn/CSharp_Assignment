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

        public IEnumerable<Book> GetAllInclude()
        {
            return Entities
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsEnumerable();
        }
    }
}
