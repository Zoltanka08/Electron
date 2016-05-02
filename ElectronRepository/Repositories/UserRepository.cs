using ElectronRepository.BaseRepository;
using ElectronRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronRepository.Repositories
{
    public class UserRepository : GenericRepository<ElectroShopEntities, User>, IUserRepository
    {
        public User GetById(int id)
        {
            return base.Get(u => u.id == id).First();
        }

        public IEnumerable<User> GetAll()
        {
            return base.Get();
        }

        public User GetByUsername(string username)
        {
            var users = base.Get(u => u.username.Equals(username));
            User user = null;
            if(users.Count()>0)
                user = users.First();
            return user;
        }
    }
}