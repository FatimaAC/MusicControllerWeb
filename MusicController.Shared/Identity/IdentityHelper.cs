using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MusicController.Identity.IdentityContext;
using MusicController.Identity.Model;

namespace MusicController.Shared.Identity
{
    public static class IdentityHelper
    {
        public static void IdentityContainer(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
