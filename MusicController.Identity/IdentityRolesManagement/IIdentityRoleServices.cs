using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.Identity.IdentityRolesManagement
{
    public interface IIdentityRoleServices
    {
        Task<List<IdentityRole>> GetAllRoles();
    }
}
