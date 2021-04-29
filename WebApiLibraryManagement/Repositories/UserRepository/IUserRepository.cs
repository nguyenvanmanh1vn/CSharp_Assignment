using System.Collections.Generic;
using WebApiLibraryManagement.Helpers;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        string GetMD5(string str);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        PagedList<User> GetUsers(UserParameters userParameters);
        IEnumerable<User> GetListUserByRoleId(int roleId);
        User PostLogin(string email, string password);
        IEnumerable<User> PostRegister(string email);
    }
}