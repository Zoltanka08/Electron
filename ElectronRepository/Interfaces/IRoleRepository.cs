using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronRepository.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        bool hasRight(User user, string roleName);
    }
}
