using System;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLibraryManagement.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetList();
        T GetById(int id);
        IEnumerable<T> GetAllWithDetails(params Expression<Func<T, object>>[] include);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
