using ElectronRepository.BaseRepository;
using ElectronRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronRepository.Repositories
{
    public class RoleRepository : GenericRepository<ElectroShopEntities, Role>, IRoleRepository
    {
        public IEnumerable<Role> GetAllRoles()
        {
            return base.Get();
        }

        public bool hasRight(User user, string roleName)
        {
            if (user != null)
            {
                foreach (UserRole userRole in user.UserRoles.ToList())
                {
                    var role = userRole.Role;
                    if (role.name.Equals(roleName))
                        return true;
                }
            }
            return false;
        }
    }
}