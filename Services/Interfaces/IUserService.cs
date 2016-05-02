using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronRepository;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void InsertUser(User userToInsert);
        void UpdateUser(User userToUpdate);
        void DeleteUser(User userToDelete);
        User GetUserById(int id);
        IEnumerable<User> GetAllUser();
        User GetByUsername(String username);
        void Save();
    }
}
