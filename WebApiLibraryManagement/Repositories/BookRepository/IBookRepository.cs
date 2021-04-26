using System.Collections.Generic;
using WebApiLibraryManagement.Helpers;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        PagedList<Book> GetBooks(BookParameters bookParameters);
        Book GetBookById(int id);
        IEnumerable<Book> GetListBookByCategoryId(int categoryId);
    }
}