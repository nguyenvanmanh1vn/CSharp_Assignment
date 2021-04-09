using System.Collections.Generic;
using MVCWebAPI.Models;

namespace MVCWebAPI.BussinessLogics
{
    public interface IMemberHandler
    {
        // 1. Return list members who is Male
        List<Member> FilterMemberByGender(string gender);


        // 2. Return the oldest members
        Member ReturnTheOldestMember();


        // 3. Return full name of members
        List<string> GetMemberWithFullNameOnly();


        // 4.1 Return list of member who has birth year is 2000
        List<Member> FilterMemberByBirthYear(int year);


        // 4.2 Return list of member who has birth year less than 2000
        List<Member> FilterMemberByBirthYearLessThan(int year);


        // 4.3 Return list of member who has birth year greather than 2000
        List<Member> FilterMemberByBirthYearGreatherThan(int year);


        // 5. Return the list members who born in HN
        List<Member> FilterMemberByBirthPlace(string place);

        // 6. Return List of member who join class before 22/03/2021.
        List<Member> MemberJoinBefore22032021();

        // CRUD
        // Create(Insert) Member
        List<Member> AddNewMember(Member member);
        void InsertMember(Member emp);
        // Read Member
        List<Member> SelectAllMembers();
        Member SelectMemberById(int id);
        // Update Member
        void UpdateMember(Member emp);
        // Delete Member
        void DeleteMember(int id);
    }
}