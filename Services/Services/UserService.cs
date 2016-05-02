using ElectronRepository;
using ElectronRepository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void InsertUser(User userToInsert)
        {
            userRepository.Insert(userToInsert);
            userRepository.Save();
        }

        public void UpdateUser(User userToUpdate)
        {
            userRepository.Update(userToUpdate);
            userRepository.Save();
        }

        public void DeleteUser(User userToDelete)
        {
            userRepository.Delete(userToDelete);
            userRepository.Save();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetById(id);
        }

        public IEnumerable<User> GetAllUser()
        {
            return userRepository.GetAll();
        }

        public User GetByUsername(String username)
        {
            return userRepository.GetByUsername(username);
        }


        public void Save()
        {
            userRepository.Save();
        }
    }
}