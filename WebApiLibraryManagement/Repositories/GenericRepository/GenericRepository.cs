using Microsoft.EntityFrameworkCore;
using WebApiLibraryManagement.Models.FluentAPI.Relationships.Required;
using WebApiLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiLibraryManagement.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MyContext Context;
        protected readonly DbSet<T> Entities;
        public GenericRepository(MyContext context)
        {
            this.Context = context;
            Entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = Entities.AsQueryable();
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }
        public T Get(long id)
        {
            return Entities.SingleOrDefault(s => s.Id == id);
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
