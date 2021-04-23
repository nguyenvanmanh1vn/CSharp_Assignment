using System.Collections.Generic;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        string GetMD5(string str);
        IEnumerable<User> GetAllInclude();
        IEnumerable<User> GetListUserByRoleId(int roleId);
        User PostLogin(string email, string password);
        IEnumerable<User> PostRegister(string email);
    }
}