using System;

namespace MVCWebAPI.Models
{
    public class Member:Person
    {
        public DateTime StartDate{get;set;}
        public DateTime EndDate{get;set;}
    }
}
