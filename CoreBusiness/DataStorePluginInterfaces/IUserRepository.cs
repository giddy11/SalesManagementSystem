using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.DataStorePluginInterfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        //void CreateUser(string name, string email, string username, string password);
        void DeleteUser(Guid userId);
        User GetUserById(Guid userId);
        IEnumerable<User> GetUsers();
        bool IsUserEmailExist(string email);

        bool IsUserExist(Guid userId);
        bool IsUserIdExist(Guid userId);
        bool IsUsernameExist(string username);
        void UpdateUser(User user);
    }
}
