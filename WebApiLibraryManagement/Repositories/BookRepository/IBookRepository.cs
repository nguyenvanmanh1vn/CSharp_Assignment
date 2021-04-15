using System.Collections.Generic;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories.BookRepository
{
public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetAllInclude();
        Book GetBookById(int id);
    }
}