using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestExc.Models;

namespace UnitTestExc.Controllers.Tests.BookServices
{
    public interface IBookServices
    {
        public Task<List<Book>> GetAll ();
        public Task<Book> GetBookById (int id);
    }
}
