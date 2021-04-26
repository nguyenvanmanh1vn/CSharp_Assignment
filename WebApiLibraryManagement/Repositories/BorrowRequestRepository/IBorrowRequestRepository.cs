using System;
using System.Collections.Generic;
using WebApiLibraryManagement.Helpers;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IBorrowRequestRepository : IGenericRepository<BorrowRequest>
    {
        PagedList<BorrowRequest> GetBorrowRequests(BorrowRequestParameters borrowRequestParameters);
        IEnumerable<BorrowRequest> GetListBorrowRequestByUserId(int userId);
        IEnumerable<BorrowRequest> GetListBorrowRequestByUserIdAndBorrowDate(int userId, int thisMonth);
    }
}