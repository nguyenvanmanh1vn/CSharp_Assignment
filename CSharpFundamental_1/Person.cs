using System;

namespace CSharpFundamental_1
{
    public enum Gender
    {
        Male,
        Female,
    };
    public enum IsGraduated
    {
        Yes,
        No,
    };
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private Gender gender;
        private DateTime dateOfBirth;
        private string phoneNumber;
        private string birthPlace;
        private IsGraduated isGraduated;

        public int Id
        {
            set
            {
                this.id = value;
            }
            get
            {
                return this.id;
            }
        }
        public string FirstName
        {
            set
            {
                this.firstName = value;
            }
            get
            {
                return this.firstName;
            }
        }
        public string LastName
        {
            set
            {
                this.lastName = value;
            }
            get
            {
                return this.lastName;
            }
        }
        public Gender Gender
        {
            set
            {
                this.gender = value;
            }
            get
            {
                return this.gender;
            }
        }
        public DateTime DateOfBirth
        {
            set
            {
                this.dateOfBirth = value;
            }
            get
            {
                return this.dateOfBirth;
            }
        }
        public string PhoneNumber
        {
            set
            {
                this.phoneNumber = value;
            }
            get
            {
                return this.phoneNumber;
            }
        }
        public string BirthPlace
        {
            set
            {
                this.birthPlace = value;
            }
            get
            {
                return this.birthPlace; 
            }
        }
        public IsGraduated IsGraduated
        {
            set
            {
                this.isGraduated = value;
            }
            get
            {
                return this.isGraduated;
            }
        }

        // Constructor
        public Person(int id, string firstName, string lastName, Gender gender, DateTime dateOfBirth, string phoneNumber, string birthPlace, IsGraduated isGraduated)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.birthPlace = birthPlace;
            this.isGraduated = isGraduated;
        }

        // toString infomation of person about id, ...
        override public string ToString()
           => $"{Id,3} {FirstName,6} {LastName,6} {Gender,6} {DateOfBirth.ToString("dd/MM/yyyy").Replace('-','/'),10} {PhoneNumber,11} {BirthPlace,11} {IsGraduated,4}";
        
    }    
}
