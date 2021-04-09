using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitTestExc.Models;

namespace UnitTestExc.Controllers.Tests.BookServices
{
    public class BookServiceImplementation : IBookServices
    {
        public async Task<List<Book>> GetAll()
        {
            using (var context = new EFCoreWebDemoContext())
            {
                var model = await context.Books.ToListAsync();
                return model;
            }
        }

        public async Task<Book> GetBookById(int id)
        {
            using (var context = new EFCoreWebDemoContext())
            {
                var model = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
                return model;
            }
        }
    }
}