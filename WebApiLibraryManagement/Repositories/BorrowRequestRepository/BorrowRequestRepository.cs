using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using WebApiLibraryManagement.Helpers;

namespace WebApiLibraryManagement.Repositories
{
    public class BorrowRequestRepository : GenericRepository<BorrowRequest>, IBorrowRequestRepository
    {
        public BorrowRequestRepository(RepositoryContext context) : base(context)
        {
        }

        public PagedList<BorrowRequest> GetBorrowRequests(BorrowRequestParameters borrowRequestParameters)
        {
            return PagedList<BorrowRequest>
                    .ToPagedList(Entities
                    .OrderBy(b => b.Id),
                borrowRequestParameters.PageNumber,
                borrowRequestParameters.PageSize);
        }

        public IEnumerable<BorrowRequest> GetListBorrowRequestByUserId(int userId)
        {
            return Entities.Where(br => br.UserId == userId).ToList();
        }
        public IEnumerable<BorrowRequest> GetListBorrowRequestByUserIdAndBorrowDate(int userId, int thisMonth)
        {
            return Entities.Where(br => br.UserId == userId && br.CreatedDate.Month == thisMonth);
        }
    }
}
