using ElectronRepository;
using ElectronRepository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return roleRepository.GetAllRoles();
        }

        public bool hasRight(User user, string roleName)
        {
            return roleRepository.hasRight(user, roleName);
        }
    }
}