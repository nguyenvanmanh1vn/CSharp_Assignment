using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiLibraryManagement.Repositories
{
    public class BorrowingRequestRepository : GenericRepository<BorrowingRequest>, IBorrowingRequestRepository
    {
        public BorrowingRequestRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<BorrowingRequest> ListBorrowingRequestByUserId(int userId)
        {
            return Entities.Where(br => br.UserId == userId).ToList();
        }
    }
}
