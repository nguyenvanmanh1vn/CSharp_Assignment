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
using WebApiLibraryManagement.Services;
using Newtonsoft.Json;

// https://localhost:5001/swagger/index.html
namespace WebApiLibraryManagement.Controllers
{
    #region TodoController
    [Route("api/")]
    [ApiController]
    public class BorrowRequestController : ControllerBase
    {
        private readonly ILogger<BorrowRequestController> _logger;
        private readonly IBorrowRequestRepository _repository;
        private readonly IBorrowRequestDetailsRepository _bRDRepository;
        private readonly IBorrowRequestServices _services;

        public BorrowRequestController(ILogger<BorrowRequestController> logger, IBorrowRequestRepository repository, IBorrowRequestDetailsRepository bRDRepository, IBorrowRequestServices services)
        {
            _logger = logger;
            _repository = repository;
            _bRDRepository = bRDRepository;
            _services = services;
        }
        #endregion

        // GET: api/BorrowRequest
        #region snippet_Get_List_BorrowRequest
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("borrowRequests")]
        public IActionResult GetListBorrowRequest([FromQuery] BorrowRequestParameters borrowRequestParameters)
        {
            try
            {
                var borrowRequests = _repository.GetBorrowRequests(borrowRequestParameters);
                var metadata = new
                {
                    borrowRequests.TotalCount,
                    borrowRequests.PageSize,
                    borrowRequests.CurrentPage,
                    borrowRequests.TotalPages,
                    borrowRequests.HasNext,
                    borrowRequests.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                _logger.LogInformation($"Returned {borrowRequests.TotalCount} borrowRequests from database.");

                return Ok(borrowRequests);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetList action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/BorrowRequest/:id
        #region snippet_Get_BorrowRequest_By_Id
        // [Authorize(Roles = "Admin")]
        [HttpGet("borrowRequest/{id}", Name = "BorrowRequestById")]
        public IActionResult GetBorrowRequestById(int id)
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

        // POST api/BorrowRequests
        #region snippet_Create
        // [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [Route("borrowRequests")]
        public IActionResult CreateBorrowRequest([FromBody] BorrowRequestDTO borrowRequestDTO)
        {
            try
            {
                if (borrowRequestDTO == null)
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
                    // int[] arrayBookIds = _services.arrayBookIds(borrowRequestDTO);
                    bool isBRValid = _services.IsBRInABRValid(borrowRequestDTO);
                    bool isBRInAMonthValid = _services.IsNumberOfTimesBRInMonthValid(borrowRequestDTO);

                    if (isBRValid == false) return ValidationProblem("One borrowing request more than 1 book(maximum is 5 books)");

                    if (isBRInAMonthValid == false) return ValidationProblem("You can't create 3 borrow requests in a month");

                    BorrowRequest entity = _services.CreateBorrowRequest(borrowRequestDTO);

                    _services.CreateBorrowRequestDetails(entity.Id, borrowRequestDTO);

                    return CreatedAtRoute("BorrowingRequestById", new { id = entity.Id }, entity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Create Borrow Request action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // PUT api/BorrowRequest/:id
        #region snippet_Update
        // [Authorize(Roles = "Admin")]
        [HttpPut("borrowRequest/{id}")]
        public ActionResult UpdateBorrowRequest(int id, [FromBody] BorrowRequest newBorrowingRequest)
        {
            try
            {
                var oldBorrowingRequest = _repository.GetBorrowRequestById(id);

                if (newBorrowingRequest == null)
                {
                    _logger.LogError("BorrowingRequest object sent from client is null.");
                    return BadRequest("BorrowingRequest object is null");
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
                    var borrowingRequestEntity = new BorrowRequest
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

        // DELETE api/BorrowRequest/:id
        #region snippet_Delete
        // [Authorize(Roles = "Admin")]
        [HttpDelete("borrowRequest/{id}")]
        public IActionResult DeleteBorrowRequest(int id)
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

        // GET: api/BorrowRequest/getlistbyuserid?userid=1
        #region snippet_Get_List_BorrowingRequest_By_User_Id
        // [Authorize(Roles = "User, Admin")]
        [HttpGet]
        [Route("borrowRequests/getListByUserId")]
        public IActionResult GetListBorrowRequestByUserId([FromQuery] int userId)
        {
            try
            {
                var listBorrowingRequest = _repository.GetListBorrowRequestByUserId(userId);

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
