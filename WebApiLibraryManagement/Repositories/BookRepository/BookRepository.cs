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
                        .AsQueryable()
                        .Include(b => b.Author)
                        .Include(b => b.Category)
                        .OrderBy(b => b.Title),
                    bookParameters.PageNumber,
                    bookParameters.PageSize);
        }

        public IEnumerable<Book> GetListBookByCategoryId(int categoryId)
        {
            return Entities.Where(b => b.CategoryId == categoryId).ToList();
        }
        public Book GetBookById(int id)
        {
            return Entities.AsNoTracking().AsQueryable().Include(b => b.Author).Include(b => b.Category).SingleOrDefault(b => b.Id == id);
        }
    }
}
