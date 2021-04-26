using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApiLibraryManagement.Helpers;

namespace WebApiLibraryManagement.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public PagedList<Book> GetBooks(BookParameters bookParameters)
        {
            return PagedList<Book>
                    .ToPagedList(Entities
                    .OrderBy(b => b.Title),
                bookParameters.PageNumber,
                bookParameters.PageSize);
        }

        public IEnumerable<Book> GetListBookByCategoryId(int categoryId)
        {
            return Entities.Where(b => b.CategoryId == categoryId).ToList();
        }
    }
}
