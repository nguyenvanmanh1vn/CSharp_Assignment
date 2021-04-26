using System.Collections.Generic;
using WebApiLibraryManagement.Helpers;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        PagedList<Book> GetBooks(BookParameters bookParameters);
        IEnumerable<Book> GetListBookByCategoryId(int categoryId);
    }
}