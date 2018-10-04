using System;
using System.Collections.Generic;
using DFO.Entities;
using DFO.Repository;
namespace DFO.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }
        public bool UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }
        public bool DeleteUser(int id)
        {
            return _userRepository.Delete(id);
        }
        public User GetUser(int id)
        {
            return _userRepository.GetById(id);
        }
        public bool AddUser(User user)
        {
            return _userRepository.Add(user);
        }
    }
}
