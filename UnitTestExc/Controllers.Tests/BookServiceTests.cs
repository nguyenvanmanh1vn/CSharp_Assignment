using System;
using System.Linq;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnitTestExc.Models;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTestExc.Controllers.Tests.BookServices
{
    
    public class BookServiceTests
    {
        // [SetUp]
        // public void SetUp()
        // {
        //     var mocking = new Mock<IBookServices>();
        //     // _bookServiceImplementation = new BookController(mocking.Object);
        // }
        
        [Fact]
        public async Task Get_AllBook_ReturnCount2()
        {
            var mocking = new Mock<IBookServices>();
            mocking.Setup(x => x.GetAll()).ReturnsAsync(FakeBookEntity());

            var controller = new BookController(mocking.Object);
            // ACT
            var result = await controller.Index();

            // Assert
             var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async void GetBook_BookId_ReturnBookIdEqual2()
        {
            var mocking = new Mock<IBookServices>();
            mocking.Setup(x => x.GetAll()).ReturnsAsync(FakeBookEntity());

            var controller = new BookController(mocking.Object);
            // ACT
            var result = await controller.Index();

            // Assert
             var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private List<Book> FakeBookEntity()
        {
            return new List<Book>{
                new Book{
                    BookId = 1,
                    Title =  "HTML",
                    AuthorId =  1,
                },
                new Book{
                    BookId = 2,
                    Title =  "CSS",
                    AuthorId =  1,
                },
                new Book{
                    BookId = 3,
                    Title =  "JavaScript",
                    AuthorId =  2,
                },
                new Book{
                    BookId = 4,
                    Title =  "C#",
                    AuthorId =  2,
                },
                new Book{
                    BookId = 5,
                    Title =  "ReactJS",
                    AuthorId =  2,
                },
            };
        }   
    }
    
}