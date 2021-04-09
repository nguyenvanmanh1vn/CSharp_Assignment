using System;

namespace GettingStarted.Models
{
    public class Member : Person
    {
        private DateTime startDate;
        private DateTime endDate;
        public DateTime StartDate
        {
            set
            {
                this.startDate = value;
            }
            get
            {
                return this.startDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                this.endDate = value;
            }
            get
            {
                return this.endDate;
            }
        }
        public Member(int id, string firstName, string lastName, Gender gender, DateTime dateOfBirth, string phoneNumber, string birthPlace, IsGraduated isGraduated, DateTime startDate, DateTime endDate) 
                : base(id, firstName, lastName, gender, dateOfBirth, phoneNumber, birthPlace, isGraduated)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        // toString infomation of person about id, ...
        override public string ToString()
           => $"{Id,3} {FirstName,6} {LastName,6} {Gender,6} {DateOfBirth.ToString("dd/MM/yyyy").Replace('-','/'),10} {PhoneNumber,10} {BirthPlace,11} {IsGraduated,3} {StartDate.ToString("dd/MM/yyyy").Replace('-','/'), 10} {EndDate.ToString("dd/MM/yyyy").Replace('-','/'), 10}";
        
    }
}