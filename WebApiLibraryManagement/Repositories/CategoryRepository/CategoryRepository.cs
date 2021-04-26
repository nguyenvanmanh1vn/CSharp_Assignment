using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApiLibraryManagement.Helpers;

namespace WebApiLibraryManagement.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }
        public PagedList<Category> GetCategories(CategoryParameters categoryParameters)
        {
            return PagedList<Category>
                    .ToPagedList(Entities
                    .OrderBy(b => b.Name),
                categoryParameters.PageNumber,
                categoryParameters.PageSize);
        }
    }
}
