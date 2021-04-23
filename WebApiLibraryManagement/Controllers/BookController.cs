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

// https://localhost:5001/swagger/index.html
namespace WebApiLibraryManagement.Controllers
{
    #region TodoController
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookRepository _repository;

        public BookController(ILogger<BookController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        #endregion

        // GET: api/books
        #region snippet_Get_List_Book
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/books")]
        public IActionResult GetListBook()
        {
            try
            {
                var books = _repository.GetList();
                _logger.LogInformation($"Returned all books from database.");

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
        [HttpGet("{id}", Name = "BookById")]
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
        [Route("api/books/get/all")]
        public IEnumerable<Book> GetAllBooksWithDetails()
        {
            // return _repository.GetAllInclude();
            return _repository.GetAllWithDetails(b => b.Author, b => b.Category).Select(b => new Book
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author != null ? new Author
                {
                    Id = b.Author.Id,
                    FirstName = b.Author.FirstName,
                    LastName = b.Author.LastName
                } : null,
                Category = b.Category != null ? new Category
                {
                    Id = b.Category.Id,
                    Name = b.Category.Name
                } : null
            });
        }
        #endregion

        // POST api/book
        #region snippet_Create
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("api/books")]
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
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
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
        [Route("api/books/getListByCategoryId")]
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
