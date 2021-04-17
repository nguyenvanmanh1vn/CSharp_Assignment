using System.Collections.Generic;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IBorrowingRequestRepository : IGenericRepository<BorrowingRequest>
    {
        IEnumerable<BorrowingRequest> ListBorrowingRequestByUserId(int userId);
    }
}