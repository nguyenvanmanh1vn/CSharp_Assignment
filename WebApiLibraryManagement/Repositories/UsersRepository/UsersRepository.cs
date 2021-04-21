using WebApiLibraryManagement.Repositories;
using WebApiLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System;
using WebApiLibraryManagement.Services;

namespace WebApiLibraryManagement.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository, IDisposable
    {
        // protected readonly IUserServices _services;
        public UsersRepository(RepositoryContext context) : base(context)
        {
        }

        // Eager Loading of Related Data
        public IEnumerable<User> GetAllInclude()
        {
            return Entities
                .Include(u => u.Role)
                .ToList();
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
            // return Entities.Where(s => s.Email == email && s.Password == _services.GetMD5(password)).FirstOrDefault();
            return Entities.Where(s => s.Email == email && s.Password == password).FirstOrDefault();
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
