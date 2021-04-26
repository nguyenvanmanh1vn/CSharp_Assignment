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
using System.IO;
using WebApiLibraryManagement.Services;
using Newtonsoft.Json;

// https://localhost:5001/swagger/index.html
namespace WebApiLibraryManagement.Controllers
{
    #region TodoController
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _repository;
        private readonly IUserServices _services;

        public UserController(ILogger<UserController> logger, IUserRepository repository, IUserServices services)
        {
            _logger = logger;
            _repository = repository;
            _services = services;
        }
        #endregion

        // api/users/login
        #region Post_Login
        [HttpPost]
        [Route("users/login")]
        public ActionResult PostLogin([FromBody] FormUserLogin _user)
        {
            try
            {
                var check = _repository.PostLogin(_user.Email, _user.Password);
                if (check.Id > 0)
                {
                    return Ok(check);
                }
                return Ok(0);

            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
        #endregion

        // api/users/register
        // #region Post
        // [HttpPost]
        // [Route("users/register")]
        // public async Task<ActionResult> PostRegister([FromBody] FormUserRegister _user)
        // {
        //     var check = _repository.PostRegister(_user.Email);
        //     if (check.Count() > 0)
        //     {
        //         return Ok(-1);
        //     }
        //     var user = new User
        //     {
        //         FirstName = _user.FirstName,
        //         Age = _user.Age,
        //         Email = _user.Email.ToLower(),
        //         Address = _user.Address,
        //         Password = _services.GetMD5(_user.Password),
        //         DateOfBirth = _user.DateOfBirth

        //     };
        //     var filesPath = Directory.GetCurrentDirectory() + "/images";
        //     //get filename
        //     string ImageName = Path.GetFileName(_user.Avatar.FileName);
        //     var fullFilePath = Path.Combine(filesPath, ImageName);
        //     using (var stream = new FileStream(fullFilePath, FileMode.Create))
        //     {
        //         await _user.Avatar.CopyToAsync(stream);
        //     }
        //     user.Avatar = filesPath + "/" + ImageName;

        //    _repository.Insert(user);
        //     int _insertID = user.Id;
        //     if (_insertID > 0)
        //     {
        //         return Ok(_insertID);
        //     }
        //     return Ok(0);
        // }
        // #endregion


        // GET: api/User
        #region snippet_Get_List_User
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("users")]
        public IActionResult GetAccountsForUser([FromQuery] UserParameters parameters)
        {
            try
            {
                var accounts = _repository.GetUsers(parameters);

                var metadata = new
                {
                    accounts.TotalCount,
                    accounts.PageSize,
                    accounts.CurrentPage,
                    accounts.TotalPages,
                    accounts.HasNext,
                    accounts.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInformation($"Returned {accounts.TotalCount} users from database.");

                return Ok(accounts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetList action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // GET: api/User/:id
        #region snippet_Get_User_By_Id
        // [Authorize(Roles = "Admin")]
        [HttpGet("user/{id}", Name = "UserById")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var User = _repository.GetById(id);
                if (User == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned User with id: {id}");

                    return Ok(User);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // POST api/Users
        #region snippet_Create
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("users")]
        public IActionResult CreateUser([FromBody] User User)
        {
            try
            {
                if (User == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }

                else if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid User object sent from client.");
                    return ValidationProblem("Invalid model object");
                }

                else
                {
                    var entity = new User
                    {
                        Email = User.Email,
                        Password = User.Password,
                        FirstName = User.FirstName,
                        LastName = User.LastName,
                        Avatar = User.Avatar,
                        Address = User.Address,
                        DateOfBirth = User.DateOfBirth,
                        RoleId = 2,
                        Phone = User.Phone,
                        Age = DateTime.Now.Year - User.DateOfBirth.Year,
                        CreatedDate = DateTime.Now
                    };

                    _repository.Insert(entity);

                    return CreatedAtRoute("UserById", new { id = User.Id }, User);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Create User action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // PUT api/User/:id
        #region snippet_Update
        // [Authorize(Roles = "Admin")]
        [HttpPut("user/{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User newUser)
        {
            try
            {
                var oldUser = _repository.GetById(id);

                if (newUser == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }
                else if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid User object sent from client.");
                    return ValidationProblem("Invalid model object");
                }
                else if (oldUser == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var UserEntity = new User
                    {
                        Id = id,
                        FirstName = newUser.FirstName,
                        LastName = newUser.LastName,
                        Email = newUser.Email,
                        Avatar = newUser.Avatar,
                        Address = newUser.Address,
                        Password = newUser.Password,
                        Phone = newUser.Phone,
                        Age = DateTime.Now.Year - newUser.DateOfBirth.Year,
                        DateOfBirth = newUser.DateOfBirth,
                        RoleId = newUser.RoleId,
                        CreatedDate = oldUser.CreatedDate,
                        ModifiedDate = DateTime.Now
                    };

                    _repository.Update(UserEntity);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Update User action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // DELETE api/User/:id
        #region snippet_Delete
        // [Authorize(Roles = "Admin")]
        [HttpDelete("user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var User = _repository.GetById(id);
                if (User == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                // else if (_repositoryContext.BorrowingRequestDetails.BorrowingRequestDetailsByUser(id).Any()) 
                // {
                //     _logger.LogError($"Cannot delete User with id: {id}. It has related Borrowing Request Details. Delete those Borrowing Request Details first"); 
                //     return ValidationProblem("Cannot delete User. It has related Borrowing Request Details. Delete those Borrowing Request Details first"); 
                // }
                else
                {
                    _repository.Delete(User);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete User action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion
    }
}
