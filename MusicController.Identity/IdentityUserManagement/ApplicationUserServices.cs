using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicController.Identity.Model;
using MusicController.Identity.UserService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.Identity.IdentityUserManagement
{
    public class ApplicationUserServices : IApplicationUserServices
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly ICurrentUserService _currentUserService;

        public ApplicationUserServices(UserManager<ApplicationUser> userManager , ICurrentUserService currentUserService)
        {
            _UserManager = userManager;
            _currentUserService = currentUserService;
        }
        public async Task<List<ApplicationUser>> GetAll()
        {
            var x = await _UserManager.Users.ToListAsync();     //_roleManager.Roles().TOListAsync();
            return x;
        }
        public async Task<string> Create(ApplicationUser user)
        {
            await _UserManager.CreateAsync(user);
            return string.Empty;
        }
        public async Task<string> Edit(string userId, ApplicationUser role)
        {
            var x = await GetById(userId);
            //x.Name = role.Name;
            await _UserManager.UpdateAsync(x);
            return string.Empty;
        }
        public async Task<ApplicationUser> GetById(string userId)
        {
            var x = await _UserManager.Users.FirstOrDefaultAsync(e => e.Id == userId);
            return x;
        }
        public async Task<ApplicationUser> GetByEmail(string email)
        {
            var x = await _UserManager.FindByEmailAsync(email);
            return x;
        }
        public async Task<string> Delete(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("Id Cannot be n null");
            }
            var User = await GetById(userId);
            IdentityResult result = await _UserManager.DeleteAsync(User);
            if (result.Succeeded)
            {
                return "Ok";
                //  throw new Exception("Id Cannot be n null");
            }
            else
            {
                throw new Exception("Id Cannot be n null");
            }
        }
        public async Task<IList<string>> GetUserRoles(ApplicationUser user)
        {
            var test = await _UserManager.GetRolesAsync(user);
            return test;
        }
        public async Task AuthorizedUser(string id, bool isAuthroized, string role)
        {
            var user = await GetById(id);
            user.IsAuthorized = true;
            user.ApprovedBy = _currentUserService.UserId;
            user.IsAuthorized = isAuthroized;
            await _UserManager.UpdateAsync(user);
            await _UserManager.AddToRoleAsync(user ,role);
        }
    }
}
