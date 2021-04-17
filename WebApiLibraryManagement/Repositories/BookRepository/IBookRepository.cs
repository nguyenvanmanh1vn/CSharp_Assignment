using System.Collections.Generic;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetAllInclude();
    }
}