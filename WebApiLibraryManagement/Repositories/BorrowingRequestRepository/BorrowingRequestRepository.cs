using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiLibraryManagement.Repositories.BorrowingRequestRepository
{
    public class BorrowingRequestRepository : GenericRepository<BorrowingRequest>, IBorrowingRequestRepository
    {
        public BorrowingRequestRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
