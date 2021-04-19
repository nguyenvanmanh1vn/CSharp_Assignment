using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApiLibraryManagement.Repositories
{
    public class BorrowingRequestRepository : GenericRepository<BorrowingRequest>, IBorrowingRequestRepository
    {
        public BorrowingRequestRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<BorrowingRequest> GetListBorrowingRequestByUserId(int userId)
        {
            return Entities.Where(br => br.UserId == userId).ToList();
        }
        public IEnumerable<BorrowingRequest> GetListBorrowingRequestByUserIdAndBorrowDate(int userId, int thisMonth)
        {
            return Entities.Where(br=>br.UserId==userId && br.CreatedDate.Month==thisMonth );
        }
    }
}
