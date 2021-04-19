using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApiLibraryManagement.Repositories
{
    public class BorrowingRequestDetailsRepository : IBorrowingRequestDetailsRepository
    {
        protected readonly RepositoryContext _context;
        protected readonly DbSet<BorrowingRequestDetail> _entities;
        public BorrowingRequestDetailsRepository(RepositoryContext context)
        {
            _context = context;
            _entities = context.Set<BorrowingRequestDetail>();
        }
        public void Insert(BorrowingRequestDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }
    }
}
