using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.Identity.IdentityRolesManagement
{
    public class IdentityRoleServices : IIdentityRoleServices
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityRoleServices(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }
    }
}
