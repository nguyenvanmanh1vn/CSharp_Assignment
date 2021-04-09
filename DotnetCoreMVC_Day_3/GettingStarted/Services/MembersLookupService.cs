using System.Collections.Generic;

namespace GettingStarted.Services
{
    public class MembersLookupService
    {
            public List<string> GetGenres()
            {
                return new List<string>()
                {
                    "Fiction",
                    "Thriller",
                    "Commedy",
                    "Autobiography"
                };
            }
    }
}