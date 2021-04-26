using System.Collections.Generic;
using WebApiLibraryManagement.Helpers;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        PagedList<Category> GetCategories(CategoryParameters categoryParameters);
    }
}