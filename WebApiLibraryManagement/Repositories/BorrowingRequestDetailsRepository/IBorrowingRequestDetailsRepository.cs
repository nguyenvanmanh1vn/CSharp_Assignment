using System.Collections.Generic;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IBorrowingRequestDetailsRepository
    {
        void Insert(BorrowingRequestDetail borrowingRequestDetail);
    }
}