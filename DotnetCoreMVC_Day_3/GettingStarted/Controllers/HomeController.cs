using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GettingStarted.Models;
using Microsoft.AspNetCore.Http;

namespace GettingStarted.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<User> usersInSystem = new List<User>();
        public static List<Role> rolesInSystem = new List<Role>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            rolesInSystem.Add(new Role{RoleId = 0, RoleName = "Admin"});
            rolesInSystem.Add(new Role{RoleId = 1, RoleName = "Visitor"});

            usersInSystem.Add(new User{UserId = 0, UserName = "Admin", Password = "a", RoleId = 0});
            usersInSystem.Add(new User{UserId = 1, UserName = "User", Password = "a", RoleId = 1});
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind("UserId,UserName,Password")] User userLogin)
        {
            if(ModelState.IsValid)
            {
                var user = usersInSystem.FirstOrDefault(x => x.UserName.Equals(userLogin));
                if(user != null)
                {
                    // add session
                    HttpContext.Session.SetString("username", user.UserName);
                    var role = rolesInSystem.FirstOrDefault(x=> x.RoleId == user.RoleId);
                    if(role != null)
                    {
                        HttpContext.Session.SetString("role", role.RoleName);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
