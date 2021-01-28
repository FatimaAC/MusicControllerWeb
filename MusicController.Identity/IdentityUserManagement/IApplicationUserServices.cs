using MusicController.Identity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.Identity.IdentityUserManagement
{
    public interface IApplicationUserServices
    {
        Task<List<ApplicationUser>> GetAll();
        Task<string> Create(ApplicationUser user);
        Task<string> Edit(string userId, ApplicationUser role);
        Task<ApplicationUser> GetById(string userId);
        Task<string> Delete(string userId);
        Task<ApplicationUser> GetByEmail(string email);
        Task<List<string>> GetUserRoles(ApplicationUser user);
        Task AuthorizedUser(string id, bool isAuthroized, string role);
    }
}
