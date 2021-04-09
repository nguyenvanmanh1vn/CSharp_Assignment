using System;
using System.Collections.Generic;
using GettingStarted.Models;
using System.Linq;

namespace GettingStarted.Repository
{
    public class MemberRepository : IMemberRepository
    {        
        private List<Member> memberList;

        public MemberRepository()
        {
            SeedingData();
        }

        // 1. Return list members who is Male
        public List<Member> FilterMemberByGender(Gender gender)
        {
            var result = memberList.Where(x => x.Gender == gender).ToList();

            return result;
        }

        // 2. Return the oldest members
        public Member ReturnTheOldestMember()
        {
            var minDob = memberList.Min(x=>x.DateOfBirth);
            var result = memberList.FirstOrDefault(x => x.DateOfBirth == minDob);
            return result;
        }

        // 3. Return full name of members
        public List<string> GetMemberWithFullNameOnly()
        {
            var result  = memberList.Select(x => $"{x.FirstName + x.LastName}").ToList();

            return result;  
        }

        // 4.1 Return list of member who has birth year is 2000
        public List<Member> FilterMemberByBirthYear(int year)
        {
            var result = memberList.Where(x => x.DateOfBirth.Year == year).ToList();

            return result;
        }

        // 4.2 Return list of member who has birth year less than 2000
        public List<Member> FilterMemberByBirthYearLessThan(int year)
        {
            var result = memberList.Where(x => x.DateOfBirth.Year < year).ToList();

            return result;
        }

        // 4.3 Return list of member who has birth year greather than 2000
        public List<Member> FilterMemberByBirthYearGreatherThan(int year)
        {
            var result = memberList.Where(x => x.DateOfBirth.Year > year).ToList();

            return result;
        }

        // 5. Return the list members who born in HN
        public List<Member> FilterMemberByBirthPlace(string place)
        {
            var result = memberList.Where(x=>x.BirthPlace == place).ToList();

            return result;
        }

        // 6. Return List of member who join class before 22/03/2021.
        public  List<Member> MemberJoinBefore22032021(){
                return memberList.FindAll(p=>p.StartDate < new DateTime(2021,3,22));
        }

        // CRUD
        // Create(Insert) Member
        public List<Member> AddNewMember(Member member)
        {
            memberList.Add(member);
            return memberList;
        }
        public void InsertMember(Member member)
        {
            memberList.Add(member);
        }

        // Read Member
        public List<Member> SelectAllMembers()
        {
            return memberList;
        }

        public Member SelectMemberById(int id)
        {
            return memberList.Find(x=>x.Id == id);
        }

        // Update Member
        public void UpdateMember(Member member)
        {
            Member memberUpdate = memberList.Find(x => x.Id == member.Id);
            memberUpdate.FirstName = member.FirstName;
            memberUpdate.LastName = member.LastName;
            memberUpdate.Gender = member.Gender;
            memberUpdate.DateOfBirth = member.DateOfBirth;
        }

        // Delete Member
        public void DeleteMember(int id)
        {
            Member memberDelete = memberList.Find(x => x.Id == id);
            memberList.Remove(memberDelete);
        }

        private void SeedingData()
        {
            memberList = new List<Member>
            {
                new Member
                (
                    1,
                    "Thanh",
                    "Le",
                    Gender.Male,
                    DateTime.Now.AddYears(-30),
                    "0123456789",
                    "Ha Noi",
                    IsGraduated.Yes,
                    DateTime.Now.AddYears(-10),
                    DateTime.Now.AddYears(5)
                ),
                new Member
                (
                    2,
                    "Manh",
                    "Nguyen",
                    Gender.Male,
                    DateTime.Now.AddYears(-24),
                    "0123456789",
                    "Ha Noi",
                    IsGraduated.Yes,
                    DateTime.Now.AddYears(-10),
                    DateTime.Now.AddYears(5)
                ),
                new Member
                (
                    3,
                    "Thao",
                    "Vu",
                    Gender.Female,
                    DateTime.Now.AddYears(-26),
                    "0123456789",
                    "Bac Ninh",
                    IsGraduated.Yes,
                    DateTime.Now.AddYears(-10),
                    DateTime.Now.AddYears(5)
                ),
                new Member
                (
                    4,
                    "Thang",
                    "Nguyen",
                    Gender.Male,
                    DateTime.Now.AddYears(-15),
                    "0123456789",
                    "Da Nang",
                    IsGraduated.Yes,
                    DateTime.Now.AddYears(-10),
                    DateTime.Now.AddYears(5)
                ),
                new Member
                (
                    5,
                    "Phuong",
                    "Nguyen",
                    Gender.Female,
                    DateTime.Now.AddYears(-20),
                    "0123456789",
                    "Ha Noi",
                    IsGraduated.No,
                    DateTime.Now.AddYears(-10),
                    DateTime.Now.AddYears(5)
                ),
            };
        }
    }
}