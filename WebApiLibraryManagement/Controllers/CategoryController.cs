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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository _repository;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        #endregion

        // GET: api/categories
        #region snippet_Get_List_Category
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("categories")]
        public IActionResult GetListCategory([FromQuery] CategoryParameters categoryParameters)
        {
            try
            {
                var categories = _repository.GetCategories(categoryParameters);
                var metadata = new
                {
                    categories.TotalCount,
                    categories.PageSize,
                    categories.CurrentPage,
                    categories.TotalPages,
                    categories.HasNext,
                    categories.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                _logger.LogInformation($"Returned {categories.TotalCount} categories from database.");

                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetList action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/category/:id
        #region snippet_Get_Category_By_Id
        // [Authorize(Roles = "Admin")]
        [HttpGet("category/{id}", Name = "CategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _repository.GetById(id);
                if (category == null)
                {
                    _logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned category with id: {id}");

                    return Ok(category);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCategoryById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // POST api/categories
        #region snippet_Create
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("categories")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            try
            {
                if (category == null)
                {
                    _logger.LogError("Category object sent from client is null.");
                    return BadRequest("Category object is null");
                }

                else if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Category object sent from client.");
                    return ValidationProblem("Invalid model object");
                }

                else
                {
                    var entity = new Category
                    {
                        Name = category.Name,
                        CreatedDate = DateTime.Now
                    };

                    _repository.Insert(entity);

                    return CreatedAtRoute("CategoryById", new { id = category.Id }, category);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Create Category action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // PUT api/category/:id
        #region snippet_Update
        // [Authorize(Roles = "Admin")]
        [HttpPut("category/{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] Category newCategory)
        {
            try
            {
                var oldCategory = _repository.GetById(id);

                if (newCategory == null)
                {
                    _logger.LogError("Category object sent from client is null.");
                    return BadRequest("Category object is null");
                }
                else if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Category object sent from client.");
                    return ValidationProblem("Invalid model object");
                }
                else if (oldCategory == null)
                {
                    _logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var categoryEntity = new Category
                    {
                        Id = id,
                        Name = newCategory.Name,
                        CreatedDate = oldCategory.CreatedDate,
                        ModifiedDate = DateTime.Now
                    };

                    _repository.Update(categoryEntity);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Update Category action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // DELETE api/category/:id
        #region snippet_Delete
        // [Authorize(Roles = "Admin")]
        [HttpDelete("category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _repository.GetById(id);
                if (category == null)
                {
                    _logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                // else if (_repositoryContext.BorrowingRequestDetails.BorrowingRequestDetailsByCategory(id).Any()) 
                // {
                //     _logger.LogError($"Cannot delete category with id: {id}. It has related Borrowing Request Details. Delete those Borrowing Request Details first"); 
                //     return ValidationProblem("Cannot delete category. It has related Borrowing Request Details. Delete those Borrowing Request Details first"); 
                // }
                else
                {
                    _repository.Delete(category);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete Category action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion
    }
}
