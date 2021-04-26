using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiLibraryManagement.Models;
using WebApiLibraryManagement.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

// https://localhost:5001/swagger/index.html
namespace WebApiLibraryManagement.Controllers
{
    #region TodoController
    [Route("api/")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _repository;

        public BooksController(ILogger<BooksController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        #endregion

        // // GET: api/books
        // #region snippet_Get_List_Book
        // // [Authorize(Roles = "Admin")]
        // [HttpGet]
        // [Route("books")]
        // public IActionResult GetListBook()
        // {
        //     try
        //     {
        //         var books = _repository.GetList();
        //         _logger.LogInformation($"Returned all books from database.");

        //         return Ok(books);
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError($"Something went wrong inside GetList action: {ex.Message}");
        //         return StatusCode(500, "Internal server error");
        //     }
        // }
        // #endregion

        // GET: api/books
        #region snippet_Get_Books_Paging
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("books")]
        public IActionResult GetBooksPaging([FromQuery] BookParameters bookParameters)
        {
            try
            {
                var books = _repository.GetBooks(bookParameters);

                var metadata = new
                {
                    books.TotalCount,
                    books.PageSize,
                    books.CurrentPage,
                    books.TotalPages,
                    books.HasNext,
                    books.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                _logger.LogInformation($"Returned {books.TotalCount} books from database.");

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetList action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/book/:id
        #region snippet_Get_Book_By_Id
        // [Authorize(Roles = "Admin")]
        [HttpGet("book/{id}", Name = "BookById")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var book = _repository.GetById(id);
                if (book == null)
                {
                    _logger.LogError($"Book with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned book with id: {id}");

                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBookById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/book/get/all
        #region snippet_Get_All_Books_With_Details
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("books/get/all")]
        public IEnumerable<Book> GetAllBooksWithDetails()
        {
            // return _repository.GetAllInclude();
            return _repository.GetByQueryConditions().AsQueryable().Include(b => b.Author).ThenInclude(a => a.Books).Include(b => b.Category);
        }
        #endregion

        // POST api/book
        #region snippet_Create
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("books")]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    _logger.LogError("Book object sent from client is null.");
                    return BadRequest("Book object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid book object sent from client.");
                    return ValidationProblem("Invalid model object");
                }

                var entity = new Book
                {
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    CategoryId = book.CategoryId,
                    CreatedDate = DateTime.Now
                };

                _repository.Insert(entity);

                return CreatedAtRoute("BookById", new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Create Category action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // PUT api/book/:id
        #region snippet_Update
        // [Authorize(Roles = "Admin")]
        [HttpPut("book/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book newBook)
        {
            try
            {
                var oldBook = _repository.GetById(id);

                if (newBook == null)
                {
                    _logger.LogError("Book object sent from client is null.");
                    return BadRequest("Book object is null");
                }
                else if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid book object sent from client.");
                    return ValidationProblem("Invalid model object");
                }
                else if (oldBook == null)
                {
                    _logger.LogError($"Book with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var bookEntity = new Book
                    {
                        Id = id,
                        Title = newBook.Title,
                        AuthorId = newBook.AuthorId,
                        CategoryId = newBook.CategoryId,
                        CreatedDate = oldBook.CreatedDate,
                        ModifiedDate = DateTime.Now
                    };

                    _repository.Update(bookEntity);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateBook action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // DELETE api/book/:id
        #region snippet_Delete
        // [Authorize(Roles = "Admin")]
        [HttpDelete("book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var book = _repository.GetById(id);
                if (book == null)
                {
                    _logger.LogError($"Book with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                // else if (_repositoryContext.BorrowingRequestDetails.BorrowingRequestDetailsByBook(id).Any()) 
                // {
                //     _logger.LogError($"Cannot delete book with id: {id}. It has related Borrowing Request Details. Delete those Borrowing Request Details first"); 
                //     return ValidationProblem("Cannot delete book. It has related Borrowing Request Details. Delete those Borrowing Request Details first"); 
                // }
                else
                {
                    _repository.Delete(book);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteBook action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/book/getlistbycategoryid?categoryid=1
        #region snippet_Get_List_Book_By_Category_Id
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("books/getListByCategoryId")]
        public IActionResult GetListByCategoryId([FromQuery] int categoryId)
        {
            try
            {
                var listBorrowingRequest = _repository.GetListBookByCategoryId(categoryId);

                _logger.LogInformation($"Returned all books from database by CategoryId.");
                return Ok(listBorrowingRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetList Book By Category Id action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion
    }
}