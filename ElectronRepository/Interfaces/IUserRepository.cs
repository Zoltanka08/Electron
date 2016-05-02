using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronRepository.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
        void Delete(User entityToDelete);
        void Update(User entityToUpdate);
        void Insert(User entityToInsert);
        void Save();
    }
}
