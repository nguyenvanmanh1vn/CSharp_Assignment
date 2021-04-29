using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System;
using WebApiLibraryManagement.Services;
using WebApiLibraryManagement.Helpers;

namespace WebApiLibraryManagement.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository, IDisposable
    {
        // protected readonly IUserServices _services;
        public UserRepository(RepositoryContext context) : base(context)
        {
        }
        public User GetUserById(int id)
        {
            return Entities.AsNoTracking().AsQueryable().Include(b => b.Role).SingleOrDefault(b => b.Id == id);
        }
        public User GetUserByEmail(string email)
        {
            return Entities.AsNoTracking().AsQueryable().SingleOrDefault(b => b.Email == email);
        }

        public PagedList<User> GetUsers(UserParameters userParameters)
        {
            return PagedList<User>
                    .ToPagedList(Entities.Include(u => u.Role)
                    .OrderBy(b => b.FirstName),
                userParameters.PageNumber,
                userParameters.PageSize);
        }
        public string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        public IEnumerable<User> GetListUserByRoleId(int roleId)
        {
            return Entities.Where(b => b.RoleId == roleId).ToList();
        }

        public User PostLogin(string email, string password)
        {
            // return Entities.Where(u => u.Email == email && u.Password == _services.GetMD5(password)).FirstOrDefault();
            return Entities.Where(u => u.Email == email && u.Password == password).Include(u => u.Role).FirstOrDefault();
        }

        public IEnumerable<User> PostRegister(string email)
        {
            return Entities.Where(s => s.Email == email.ToLower()).ToList();
        }

        //This method is used to check and validate the user credentials
        public User ValidateUser(string email, string password)
        {
            return Entities.FirstOrDefault(user =>
            user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
            && user.Password == password);
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
