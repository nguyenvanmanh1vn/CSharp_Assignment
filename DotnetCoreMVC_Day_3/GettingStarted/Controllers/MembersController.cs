using System;
using GettingStarted.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GettingStarted.Filters;
using System.Linq;
using GettingStarted.Repository;
using Microsoft.AspNetCore.Http;

namespace GettingStarted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberHandlerAPI : ControllerBase
    {
        private IMemberRepository _memberHandler;
        public MemberHandlerAPI(IMemberRepository memberHandler)
        {
            _memberHandler = memberHandler;
        }

        // GET: https://localhost:5001/api/member/memberbygender/Female
        [HttpGet]
        [Route("/api/member/memberbygender/{gender}")]
        public List<Member> FilterMemberByGender(Gender gender)
        {
            return _memberHandler.FilterMemberByGender(gender);
        }

        // GET: https://localhost:5001/api/member/memberbybirthplace
        [HttpGet]
        [Route("/api/member/memberbybirthplace/{place}")]
        public List<Member> FilterMemberByBirthPlace(string place)
        {
            return _memberHandler.FilterMemberByBirthPlace(place);
        }
        // POST: https://localhost:5001/api/member/
        [HttpPost]
        public List<Member> Post(Member member)
        {
            return _memberHandler.AddNewMember(member);
        }
    }

    public class MembersController : Controller
    {
        // private IMemberHandler memberInList;
        // public MembersController(IMemberHandler memberHandler)
        // {
        //     memberInList = memberHandler;
        // }
        // public IActionResult Index()
        // {
        //     return View();
        // }

        // public IActionResult Details()
        // {
        //     Member member = new Member
        //     (
        //         1,
        //         "Manh",
        //         "Nguyen",
        //         Gender.Male,
        //         DateTime.Parse("1997-01-22"),
        //         "0971781597",
        //         "Ha Noi",
        //         IsGraduated.Yes,
        //         DateTime.Parse("1997-01-22"),
        //         DateTime.Parse("2021-01-22")
        //     );

        //     return View(member);
        // }

        // // GET: Members/Create
        // [Authorize("Admin")]
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: Member/Create
        // // To protect from overposting attacks, enable the specific property
        // // more details, see http://go.microsoft.com/fwlink/?LinkId=31755

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // // public IActionResult Create(Member member)
        // public IActionResult Create([Bind("Id,FirstName,LastName,Gender,DateOfBirth,PhoneNumber,BirthPlace,IsGraduated,StartDate,EndDate")] User member)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         // Logic to add the book to DB
        //         // members.Add(member);
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(member);
        //     // return View();
        // }

        // // Get: Members/Edit/5
        // public IActionResult Edit(int? id)
        // {
        //     if(id == null){
        //         return NotFound();
        //     }
        //     if(ModelState.IsValid)
        //     {
        //         var memberInList = members.FirstOrDefault(x=> x.I);
        //         if(memberInList == null)
        //         {
        //             return NotFound();
        //         }
        //         memberInList.Id == member.Id;
        //         memberInList.FirstName == member.FirstName;
        //         memberInList.LastName == member.LastName;

        //         return RedirectToAction(nameof(Index));

        //     }
        //     // return View(member);
        //     return View();
        // }

        // // // Delete: Delete member
        // public IActionResult Delete()
        // {
        //     return View();
        // }

        MemberRepository rep = new MemberRepository();
        //
        // GET: /Member/
        public ActionResult Index()
        {            
            IEnumerable<Member> obj = rep.SelectAllMembers();
            return View(obj);
        }

        //
        // GET: /Member/Details/5
        public ActionResult Details(int id)
        {            
            Member obj = rep.SelectMemberById(id);
            return View(obj);
        }

        //
        // GET: /Employee/Create
        public ActionResult Create()
        {            
            return View();
        }

        //
        // POST: /Member/Create
        [HttpPost]
        public ActionResult Create(Member emp)
        {
            try
            {
                rep.InsertMember(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Member/Edit/5
        public ActionResult Edit(int id)
        {
            Member obj = rep.SelectMemberById(id);
            return View(obj);
        }

        //
        // POST: /Member/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Member emp)
        {
            try
            {
                rep.UpdateMember(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Member/Delete/5
        public ActionResult Delete(int id)
        {
            Member obj = rep.SelectMemberById(id);
            return View(obj);
        }

        //
        // POST: /Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                rep.DeleteMember(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}