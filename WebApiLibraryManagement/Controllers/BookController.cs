using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiLibraryManagement.Models;
using WebApiLibraryManagement.Repositories.BookRepository;
using WebApiLibraryManagement.Repositories;
using Microsoft.Extensions.Logging;

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
        private readonly RepositoryContext _repositoryContext;

        public BookController(IBookRepository repository, RepositoryContext repositoryContext, ILogger<BookController> logger)
        {
            _repository = repository;
            _repositoryContext = repositoryContext;
            _logger = logger;
        }
        #endregion

        // GET: api/book
        #region snippet_Get_List_Book
        [HttpGet]
        public IEnumerable<Book> GetListBook()
        {
            return _repository.GetAll(b => b.Author, b => b.Category).Select(b => new Book
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

        // GET: api/book/5
        #region snippet_Get_Book_By_Id
        [HttpGet("{id}", Name="BookById")]
        public ActionResult<List<Book>> GetBookById(int id)
        {
            Book book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        #endregion

        // POST api/book
        #region snippet_Create
        [HttpPost]
        public ActionResult PostBook(BookForCreate model)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid model");

            try
            {
                var entity = new Book
                {
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    CategoryId = model.CategoryId,
                    CreatedDate = DateTime.Now
                };
                _repository.Insert(entity);

                // Returns an HTTP 201 status code if successful
                return CreatedAtAction(nameof(GetListBook), new { id = model.AuthorId }, model);
                // Returns an HTTP 200 status code, and getListById if successful
                // return new JsonResult(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        // PUT api/book/5
        #region snippet_Update
        [HttpPut("{id}")]
        public ActionResult PutBook(int id
        // , [FromBody] string value
        , Book model)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid model");

            try
            {
                var entity = new Book
                {
                    Id = id,
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    CategoryId = model.CategoryId,
                    ModifiedDate = DateTime.Now
                };
                _repository.Update(entity);

                return Ok();
                // return new JsonResult(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
        }
        #endregion

        // DELETE api/book/5
        #region snippet_Delete
        // [HttpDelete("{id}")]
        // public IActionResult DeleteBook(int id)
        // {
            // try
            // {
            //     if (!BookExists(id))
            //     {
            //         return NotFound();
            //     }

            //     var entity = new Book
            //     {
            //         Id = id,
            //         Title = model.Title,
            //         AuthorId = model.AuthorId,
            //         CategoryId = model.CategoryId,
            //         ModifiedDate = DateTime.Now
            //     };

            //     _repository.Delete(entity);
            //             _repository.Save();
            //     return NoContent();
            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, "Internal server error");
            // }
        // }
         #endregion

         private bool BookExists(int id) =>
             _repositoryContext.Books.Any(b=> b.Id == id);
    }
}
