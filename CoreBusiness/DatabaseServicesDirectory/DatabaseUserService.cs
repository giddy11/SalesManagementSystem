using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.DatabaseServicesDirectory
{
    public class DatabaseUserService : IDatabaseUserService
    {
        public DatabaseUserService()
        {
        }

        private readonly List<User> users = new();


        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUserById(Guid userId)
        {
            return users?.FirstOrDefault(x => x.UserId == userId);
        }


        public void CreateUser(User user)
        {
            EncryptPassword(user, user.Password);
            users.Add(user);
        }

        public bool IsUserExist(Guid userId)
        {
            User user = GetUserById(userId);
            if (user is null)
            {
                return false;
            }
            return true;
        }

        public bool IsUserIdExist(Guid userId)
        {
            var user = users.FirstOrDefault(x => x.UserId == userId);
            if (user is null)
            {
                return false;
            }
            return true;
        }

        public bool IsUserEmailExist(string email)
        {
            var user = users.FirstOrDefault(x => x.Email == email);
            if (user is null)
            {
                return false;
            }
            return true;
        }

        public bool IsUsernameExist(string username)
        {
            var user = users.FirstOrDefault(x => x.Username == username);
            if (user is null)
            {
                return false;
            }
            return true;
        }

        private void EncryptPassword(User user, string password)
        {
            var passwordEncoded = Encoding.UTF8.GetBytes(user.Password).ToString();
            user.Password = passwordEncoded;
        }


        public void UpdateUser(User user)
        {
            var nameToUpdate = GetUserById(user.UserId);
            if (nameToUpdate != null)
            {
                nameToUpdate.Name = user.Name;
            }
        }

        public void DeleteUser(Guid userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                users.Remove(user);
            }
        }


























    }
}
