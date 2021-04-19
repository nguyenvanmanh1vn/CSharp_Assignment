using System;
using System.Collections.Generic;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IBorrowingRequestRepository : IGenericRepository<BorrowingRequest>
    {
        IEnumerable<BorrowingRequest> GetListBorrowingRequestByUserId(int userId);
        IEnumerable<BorrowingRequest> GetListBorrowingRequestByUserIdAndBorrowDate(int userId, int thisMonth);
    }
}