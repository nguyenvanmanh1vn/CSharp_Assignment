using Microsoft.EntityFrameworkCore;
using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiLibraryManagement.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly RepositoryContext Context;
        protected readonly DbSet<T> Entities;
        public GenericRepository(RepositoryContext context)
        {
            this.Context = context;
            Entities = context.Set<T>();
        }
        
        public IEnumerable<T> GetList() 
        { 
            return Entities.ToList();
        }
        public T GetById(int id)
        {
            return Entities.SingleOrDefault(s => s.Id == id);
        }
        public IEnumerable<T> GetAllWithDetails(params Expression<Func<T, object>>[] includes)
        {
            var query = Entities.AsQueryable();
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Add(entity);
            Context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Update(entity);
            Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Remove(entity);
            Context.SaveChanges();
        }
    }
}
