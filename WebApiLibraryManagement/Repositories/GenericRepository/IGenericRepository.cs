using System;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApiLibraryManagement.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] include);
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
