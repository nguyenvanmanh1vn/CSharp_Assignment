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
    public class BorrowingRequestController : ControllerBase
    {
        private readonly ILogger<BorrowingRequestController> _logger;
        private readonly IBorrowingRequestRepository _repository;
        private readonly IBorrowingRequestDetailsRepository _borrowingRequestDetailsRepository;

        public BorrowingRequestController(ILogger<BorrowingRequestController> logger, IBorrowingRequestRepository repository, IBorrowingRequestDetailsRepository borrowingRequestDetailsRepository)
        {
            _logger = logger;
            _repository = repository;
            _borrowingRequestDetailsRepository = borrowingRequestDetailsRepository;
        }
        #endregion

        // GET: api/BorrowingRequest
        #region snippet_Get_List_BorrowingRequest
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetListBorrowingRequest()
        {
            try
            {
                var borrowingRequests = _repository.GetList();
                _logger.LogInformation($"Returned all borrowing Requests from database.");

                return Ok(borrowingRequests);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetList action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/BorrowingRequest/:id
        #region snippet_Get_BorrowingRequest_By_Id
        // [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "BorrowingRequestById")]
        public IActionResult GetBorrowingRequestById(int id)
        {
            try
            {
                var borrowingRequest = _repository.GetById(id);
                if (borrowingRequest == null)
                {
                    _logger.LogError($"Borrowing Request with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned Borrowing Request with id: {id}");

                    return Ok(borrowingRequest);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Get Borrowing Request By Id action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // POST api/BorrowingRequest
        #region snippet_Create
        // [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public IActionResult CreateBorrowingRequest([FromBody] BorrowingRequest borrowingRequest)
        {
            try
            {
                if (borrowingRequest == null)
                {
                    _logger.LogError("BorrowingRequest object sent from client is null.");
                    return BadRequest("BorrowingRequest object is null");
                }

                else if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid BorrowingRequest object sent from client.");
                    return ValidationProblem("Invalid model object");
                }

                else
                {
                    int[] arrayIds = Array.ConvertAll(borrowingRequest.BorrowBooks.Split(','), Int32.Parse);
                    /* Front End:
                     * string borrowingBooksRequestArrayToString = String.Join(",", borrowingBooksRequestArrayToString.Select(p => p.ToString()).ToArray());
                    */
                    var numberOfBorrowRequestsInMonth = _repository.GetAllWithDetails().Count(br => br.UserId == borrowingRequest.UserId && br.CreatedDate.Month == DateTime.Now.Month);

                    if (numberOfBorrowRequestsInMonth >= 3)
                    {
                            return ValidationProblem("You can't create 3 borrowing requests in a month");
                    }
                    if (arrayIds.Length > 5)
                    {
                        return ValidationProblem("One borrowing request more than 1 book(maximum is 5 books)");
                    }
                            
                    var entity = new BorrowingRequest
                    {
                        UserId = borrowingRequest.UserId,
                        Status = Status.Waiting,
                        BorrowBooks = borrowingRequest.BorrowBooks,
                        CreatedDate = DateTime.Now
                    };

                    _repository.Insert(entity);

                    foreach (int bookId in arrayIds)
                    {
                        var entityRequestDetails = new BorrowingRequestDetail
                        {
                            BookId = bookId,
                            BorrowingRequestId = entity.Id,
                        };
                        _borrowingRequestDetailsRepository.Insert(entityRequestDetails);
                    }

                    return CreatedAtRoute("BorrowingRequestById", new { id = borrowingRequest.Id }, entity);
                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Create Borrowing Request action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // PUT api/BorrowingRequest/:id
        #region snippet_Update
        // [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult UpdateBorrowingRequest(int id, [FromBody] BorrowingRequest newBorrowingRequest)
        {
            try
            {
                var oldBorrowingRequest = _repository.GetById(id);

                if (newBorrowingRequest == null)
                {
                    _logger.LogError("BorrowingRequest object sent from client is null.");
                    return ValidationProblem("BorrowingRequest object is null");
                }
                else if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid BorrowingRequest object sent from client.");
                    return ValidationProblem("Invalid model object");
                }
                else if (oldBorrowingRequest == null)
                {
                    _logger.LogError($"BorrowingRequest with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var borrowingRequestEntity = new BorrowingRequest
                    {
                        Id = id,
                        UserId = newBorrowingRequest.UserId,
                        Status = newBorrowingRequest.Status,
                        CreatedDate = oldBorrowingRequest.CreatedDate,
                        ModifiedDate = DateTime.Now
                    };

                    _repository.Update(borrowingRequestEntity);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Update BorrowingRequest action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // DELETE api/BorrowingRequest/:id
        #region snippet_Delete
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteBorrowingRequest(int id)
        {
            try
            {
                var borrowingRequest = _repository.GetById(id);
                if (borrowingRequest == null)
                {
                    _logger.LogError($"BorrowingRequest with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                // else if (_repositoryContext.BorrowingRequestDetails.BorrowingRequestDetailsByBorrowingRequest(id).Any()) 
                // {
                //     _logger.LogError($"Cannot delete BorrowingRequest with id: {id}. It has related Borrowing Request Details. Delete those Borrowing Request Details first"); 
                //     return ValidationProblem("Cannot delete BorrowingRequest. It has related Borrowing Request Details. Delete those Borrowing Request Details first"); 
                // }
                else
                {
                    _repository.Delete(borrowingRequest);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete BorrowingRequest action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/BorrowingRequest/getlistbyuserid?userid=1
        #region snippet_Get_List_BorrowingRequest_By_User_Id
        // [Authorize(Roles = "User, Admin")]
        [HttpGet]
        [Route("getListByUserId")]
        public IActionResult GetListBorrowingRequestByUserId([FromQuery] int userId)
        {
            try
            {
                var listBorrowingRequest = _repository.GetListBorrowingRequestByUserId(userId);

                _logger.LogInformation($"Returned all borrowing Requests from database by UserId.");
                return Ok(listBorrowingRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetList BorrowingRequest By User Id action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion
    }
}
