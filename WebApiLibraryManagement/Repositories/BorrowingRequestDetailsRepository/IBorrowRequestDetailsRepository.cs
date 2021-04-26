using System.Collections.Generic;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IBorrowRequestDetailsRepository
    {
        void Insert(BorrowRequestDetail borrowRequestDetail);
    }
}