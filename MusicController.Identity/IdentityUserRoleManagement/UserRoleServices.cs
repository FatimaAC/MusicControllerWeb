using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.Identity.IdentityUserRoleManagement
{
    public class UserRoleServices : IUserRoleServices
    {
        private readonly UserManager<IdentityUserRole<string>> _UserManager;
        public UserRoleServices(UserManager<IdentityUserRole<string>> userManager)
        {
            _UserManager = userManager;
        }
        public async Task<List<IdentityUserRole<string>>> GetAll()
        {
            var x = await _UserManager.Users.ToListAsync();
            return x;
        }
        //public async Task<string> Create(ApplicationUser user, string[] roles)
        //{
        //    await _UserManager.AddToRolesAsync(user, roles);
        //    return string.Empty;
        //}
        public async Task<string> Edit(string userId, IdentityRole role)
        {
            var x = await _UserManager.FindByIdAsync(userId);
            //x.Name = role.Name;
            await _UserManager.UpdateAsync(x);
            return string.Empty;
        }
        //public async Task<AspNetUserRoles> GetById(string userId)
        //{
        //    var x = await _UserManager.FindByIdAsync(userId);
        //    return x;
        //}
        public async Task<string> Delete(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("Id Cannot be n null");
            }

            var User = await _UserManager.FindByIdAsync(userId);
            IdentityResult result = await _UserManager.DeleteAsync(User);
            if (result.Succeeded)
            {
                throw new Exception("Id Cannot be n null");
            }
            else
            {
                throw new Exception("Id Cannot be n null");
            }
        }
    }
}

