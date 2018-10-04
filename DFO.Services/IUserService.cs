using System;
using System.Collections.Generic;
using System.Text;
using DFO.Entities;
namespace DFO.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        User GetUser(int id);
        bool AddUser(User user);
    }
}
