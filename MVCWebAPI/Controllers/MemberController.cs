using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWebAPI.BussinessLogics;
using MVCWebAPI.Models;

namespace MVCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController: ControllerBase
    {
        private IMemberHandler _memberHandler;
        public MemberController(IMemberHandler memberHandler)
        {
            _memberHandler = memberHandler;
        }

        // 1. Return list members who is Male
        // GET: https://localhost:5001/api/member/FilterMemberByGender/Male
        [HttpGet]
        [Route("/api/member/FilterMemberByGender/{gender}")]
        public List<Member> FilterMemberByGender(string gender)
        {
            return _memberHandler.FilterMemberByGender(gender);
        }

        // 2. Return the oldest members
        [HttpGet]
        [Route("/api/member/ReturnTheOldestMember")]
        public Member ReturnTheOldestMember()
        {
            return _memberHandler.ReturnTheOldestMember();
        }

        // 3. Return full name of members
        [HttpGet]
        [Route("/api/member/GetMemberWithFullNameOnly")]
        public List<string> GetMemberWithFullNameOnly()
        {
            return _memberHandler.GetMemberWithFullNameOnly();
        }


        // 4.1 Return list of member who has birth year is 2000
        [HttpGet]
        [Route("/api/member/FilterMemberByBirthYear/{year}")]
        public List<Member> FilterMemberByBirthYear(int year)
        {
            return _memberHandler.FilterMemberByBirthYear(year);
        }

        // 4.2 Return list of member who has birth year less than 2000
        [HttpGet]
        [Route("/api/member/FilterMemberByBirthYearLessThan/{year}")]
        public List<Member> FilterMemberByBirthYearLessThan(int year)
        {
            return _memberHandler.FilterMemberByBirthYearLessThan(year);
        }

        // 4.3 Return list of member who has birth year greather than 2000
        [HttpGet]
        [Route("/api/member/FilterMembersByBirthYearGreater/{year}")]
        public List<Member> FilterMemberByBirthYearGreatherThan(int year)
        {
            return _memberHandler.FilterMemberByBirthYearGreatherThan(year);
        }

        // 5. Return the list members who born in HN
        // GET: https://localhost:5001/api/member/FilterMemberByBirthPlace/{place}
        [HttpGet]
        [Route("/api/member/FilterMemberByBirthPlace/{place}")]
        public List<Member> FilterMemberByBirthPlace(string place)
        {
            return _memberHandler.FilterMemberByBirthPlace(place);
        }

        // 6. Return List of member who join class before 22/03/2021.
        [HttpGet]
        [Route("/api/member/MemberJoinBefore22032021")]
        public List<Member> MemberJoinBefore22032021()
        {
            return _memberHandler.MemberJoinBefore22032021();
        }

        // CRUD
        // Create(Insert) Member
        [HttpPost]
        [Route("/api/member/CreateMember/post")]
        public List<Member> CreateMember(Member member)
        {
            return _memberHandler.AddNewMember(member);
        }

        //
        [HttpPost]
        [Route("/api/member/Create/post")]
        public List<Member> Create(Member mem)
        {
            _memberHandler.InsertMember(mem);
            return _memberHandler.SelectAllMembers();
        }

        // Read Member
        [HttpGet]
        [Route("/api/member/SelectAllMembers")]
        public List<Member> SelectAllMembers()
        {            
            IEnumerable<Member> obj = _memberHandler.SelectAllMembers();
            return _memberHandler.SelectAllMembers();
        }

        //
        [HttpGet]
        [Route("/api/member/GetMemberById/{id}")]
        public Member GetMemberById(int id)
        {            
            Member obj = _memberHandler.SelectMemberById(id);
            return obj;
        }

        // Update Member
        [HttpPut]
        [Route("/api/member/Edit/put/{id}")]
        public List<Member> Edit(int id, Member emp)
        {
                _memberHandler.UpdateMember(emp);
                return _memberHandler.SelectAllMembers();
        }

        // Delete Member
        [HttpDelete]
        [Route("/api/member/Delete/delete/{id}")]
        public List<Member> Delete(int id)
        {
            _memberHandler.DeleteMember(id);
            return _memberHandler.SelectAllMembers();
        }
    }

}