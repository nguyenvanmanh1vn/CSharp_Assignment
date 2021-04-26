using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApiLibraryManagement.Repositories
{
    public class BorrowRequestDetailsRepository : IBorrowRequestDetailsRepository
    {
        protected readonly RepositoryContext _context;
        protected readonly DbSet<BorrowRequestDetail> _entities;
        public BorrowRequestDetailsRepository(RepositoryContext context)
        {
            _context = context;
            _entities = context.Set<BorrowRequestDetail>();
        }
        public void Insert(BorrowRequestDetail entity)
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
