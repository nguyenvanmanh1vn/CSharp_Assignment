using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFundamental_1
{
    class Program
    {
        static List<Member> memberList = new List<Member>(){
            new Member(1, "Manh", "Nguyen", Gender.Male, new DateTime(1997, 01, 22), "0971781597", "Ha Noi", IsGraduated.Yes, new DateTime(2020, 01, 22), new DateTime(2021, 03, 03)),
            new Member(2, "Tung", "Tran", Gender.Male, new DateTime(1998, 03, 24), "0971781234", "Hung Yen", IsGraduated.No, new DateTime(2021, 03, 22), new DateTime(2021, 06, 21)),
            new Member(3, "Yen", "Do", Gender.Female, new DateTime(2001, 05, 26), "0971785678", "Ho Chi Minh", IsGraduated.Yes, new DateTime(2021, 04, 23), new DateTime(2021, 05, 01)),
            new Member(4, "Trang", "Tran", Gender.Female, new DateTime(1998, 07, 28), "0971789101", "Nghe An", IsGraduated.No, new DateTime(2017, 07, 15), new DateTime(2017, 07, 30)),
            new Member(5, "Kien", "Nguyen", Gender.Male, new DateTime(1989, 09, 30), "0971781213", "Ha Noi", IsGraduated.Yes, new DateTime(2019, 09, 01), new DateTime(2019, 09, 30)),
        };
        // 1. Return a list of members who is Male
        private static void ReturnMaleMemberList(){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("1. Return a list of members who is Male");

            var maleMemberList = memberList.FindAll(
                (maleMember) => maleMember.Gender == Gender.Male
            );

            foreach (var maleMember in maleMemberList)
            {
                Console.WriteLine(maleMember.ToString());
            }
        }

        // 2. Return the oldest one (if return more than one record then select first record)
        private static void ReturnTheOldestOne(){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("\n2. Return the oldest one (if return more than one record then select first record)");
            var theOldestOne = memberList.OrderBy( m => m.DateOfBirth ).First();
            Console.WriteLine(theOldestOne.ToString());
        }

        // 3. Return a new list that contains Full Name only (Fullname = Last Name + First Name)
        private static void ReturnMemberListFullNameOnly(){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("\n3. Return a new list that contains Full Name only (Fullname = Last Name + First Name)");
            foreach (var member in memberList)
            {
                Console.WriteLine($"{member.LastName} {member.FirstName}");
            }
        }

        /* 4. Return 3 lists:
            * List of members who has birth year is 1998
            * List of members who has birth year greater than 1998
            * List of members who has birth year less than 1998
        */
        private static void ReturnMemberListHasBirthYearIs1998(){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("\n4. Return 3 lists:");
            Console.WriteLine("\n   * List of members who has birth year is 1998");
            var memberListHasBirthYearIs1998 = from m in memberList
                                                    where m.DateOfBirth >= new DateTime(1998,01,01) && m.DateOfBirth < new DateTime(1999,01,01)
                                                    select m;

            foreach (var member in memberListHasBirthYearIs1998)
            {
                Console.WriteLine(member.ToString());
            }   
        }

        private static void ReturnMemberListHasBirthYearGreaterThan1998(){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("\n   * List of members who has birth year greater than 1998");
            var memberListHasBirthYearGreaterThan1998 = from m in memberList
                                                        where m.DateOfBirth > new DateTime(1999,01,01)
                                                        select m;

            foreach (var member in memberListHasBirthYearGreaterThan1998)
            {
                Console.WriteLine(member.ToString());
            }   
        }

        private static void ReturnMemberListHasBirthYearLessThan1998(){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("\n   * List of members who has birth year less than 1998");
            var memberListHasBirthYearLessThan1998 = from m in memberList
                                                        where m.DateOfBirth < new DateTime(1998,01,01)
                                                        select m;

            foreach (var member in memberListHasBirthYearLessThan1998)
            {
                Console.WriteLine(member.ToString());
            }   
        }


        // 5. Return the first person who was born in Ha Noi.
        private static void ReturnMemberWasBornInHaNoi(){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("\n5. Return the first person who was born in Ha Noi.");
            var memberWasBornInHaNoi = memberList.Find(
                (memberWasBornInHaNoi) => memberWasBornInHaNoi.BirthPlace == "Ha Noi"
            );
            Console.WriteLine(memberWasBornInHaNoi);
        }

        // 6. Return List of member who join class before 22/03/2021.
        private static void ReturnMemberListJoinBefore_22_03_2021(){
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("\n6. Return List of member who join class before 22/03/2021.");
            var memberListJoinBefore_22_03_2021 = from m in memberList
                                                    where m.StartDate < new DateTime(2021,03,22)
                                                    select m;

            foreach (var member in memberListJoinBefore_22_03_2021)
            {
                Console.WriteLine(member.ToString());
            }     
        }

        static void Main(string[] args)
        {
            // Call method
            ReturnMaleMemberList();
            ReturnTheOldestOne();
            ReturnMemberListFullNameOnly();
            ReturnMemberListHasBirthYearIs1998();
            ReturnMemberListHasBirthYearGreaterThan1998();
            ReturnMemberListHasBirthYearLessThan1998();
            ReturnMemberWasBornInHaNoi();
            ReturnMemberListJoinBefore_22_03_2021();
        }
    }
}
