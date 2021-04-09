using System;
using System.Collections.Generic;
using System.Linq;
using MVCWebAPI.Models;

namespace MVCWebAPI.BussinessLogics
{
    public class MemberHandler : IMemberHandler
    {
        private List<Member> _listMembers;

        public MemberHandler()
        {
            SeedingData();
        }

        // 1. Return list members who is Male
        public List<Member> FilterMemberByGender(string gender)
        {
            var result = _listMembers.Where(x => x.Gender == gender).ToList();

            return result;
        }

        // 2. Return the oldest members
        public Member ReturnTheOldestMember()
        {
            var minDob = _listMembers.Min(x=>x.DoB);
            var result = _listMembers.FirstOrDefault(x => x.DoB == minDob);
            return result;
        }

        // 3. Return full name of members
        public List<string> GetMemberWithFullNameOnly()
        {
            var result  = _listMembers.Select(x => $"{x.FirstName + x.LastName}").ToList();

            return result;  
        }

        // 4.1 Return list of member who has birth year is 2000
        public List<Member> FilterMemberByBirthYear(int year)
        {
            var result = _listMembers.Where(x => x.DoB.Year == year).ToList();

            return result;
        }

        // 4.2 Return list of member who has birth year less than 2000
        public List<Member> FilterMemberByBirthYearLessThan(int year)
        {
            var result = _listMembers.Where(x => x.DoB.Year < year).ToList();

            return result;
        }

        // 4.3 Return list of member who has birth year greather than 2000
        public List<Member> FilterMemberByBirthYearGreatherThan(int year)
        {
            var result = _listMembers.Where(x => x.DoB.Year > year).ToList();

            return result;
        }

        // 5. Return the list members who born in HN
        public List<Member> FilterMemberByBirthPlace(string place)
        {
            var result = _listMembers.Where(x=>x.BirthPlace == place).ToList();

            return result;
        }

        // 6. Return List of member who join class before 22/03/2021.
        public  List<Member> MemberJoinBefore22032021(){
                return _listMembers.FindAll(p=>p.StartDate < new DateTime(2021,3,22));
        }

        // CRUD
        // Create(Insert) Member
        public List<Member> AddNewMember(Member member)
        {
            _listMembers.Add(member);
            return _listMembers;
        }
        public void InsertMember(Member member)
        {
            _listMembers.Add(member);
        }

        // Read Member
        public List<Member> SelectAllMembers()
        {
            return _listMembers;
        }

        public Member SelectMemberById(int id)
        {
            return _listMembers.Find(x=>x.Id == id);
        }

        // Update Member
        public void UpdateMember(Member member)
        {
            Member memberUpdate = _listMembers.Find(x => x.Id == member.Id);
            memberUpdate.FirstName = member.FirstName;
            memberUpdate.LastName = member.LastName;
            memberUpdate.Gender = member.Gender;
            memberUpdate.DoB = member.DoB;
        }

        // Delete Member
        public void DeleteMember(int id)
        {
            Member memberDelete = _listMembers.Find(x => x.Id == id);
            _listMembers.Remove(memberDelete);
        }

        private void SeedingData()
        {
            _listMembers = new List<Member>
            {
                new Member
                {
                    Id = 1,
                    FirstName = "Thanh",
                    LastName = "Le",
                    BirthPlace = "Ha Noi",
                    DoB = DateTime.Now.AddYears(-30),
                    Gender = "Male",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
                 new Member
                {
                    Id = 2,
                    FirstName = "Tung",
                    LastName = "Vu",
                    BirthPlace = "Bac Ninh",
                    DoB = DateTime.Now.AddYears(-24),
                    Gender = "Male",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
                  new Member
                {
                    Id = 3,
                    FirstName = "Thao",
                    LastName = "Vu",
                    BirthPlace = "Ha Noi",
                    DoB = DateTime.Now.AddYears(-26),
                    Gender = "Female",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
                   new Member
                {
                    Id = 4,
                    FirstName = "Thang",
                    LastName = "Nguyen",
                    BirthPlace = "Da Nang",
                    DoB = DateTime.Now.AddYears(-15),
                    Gender = "Male",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
                    new Member
                {
                    Id = 5,
                    FirstName = "Phuong",
                    LastName = "Nguyen",
                    BirthPlace = "Ha Noi",
                    DoB = DateTime.Now.AddYears(-20),
                    Gender = "Female",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
            };
        }
    }
}