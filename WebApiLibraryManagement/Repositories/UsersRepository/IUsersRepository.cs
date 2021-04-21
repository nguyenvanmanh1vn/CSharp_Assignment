using System.Collections.Generic;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetAllInclude();
        IEnumerable<User> GetListUserByRoleId(int roleId);
        User PostLogin(string email, string password);
        IEnumerable<User> PostRegister(string email);
    }
}