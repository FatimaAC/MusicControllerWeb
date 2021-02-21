using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using MusicController.BL.DevicesServices;
using MusicController.BL.FileServices;
using MusicController.BL.OutletServices;
using MusicController.BL.PlaylistsServices;
using MusicController.BL.SharePointFiles;
using MusicController.BL.TrackServices;
using MusicController.Identity.IdentityRolesManagement;
using MusicController.Identity.IdentityUserManagement;
using MusicController.Identity.Jwt;
using MusicController.Identity.UserService;
using MusicController.Shared.ExtensionMethod;

namespace MusicController.Shared.DIContainer
{
    // Serivces Reigstraion for Web and APi 
    public static class ServicesDIContainer
    {
        public static void ServicesContainer(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
            services.AddScoped<CustomUrlHelper>();
            services.AddScoped<IApplicationUserServices, ApplicationUserServices>();
            services.AddScoped<IIdentityRoleServices, IdentityRoleServices>();
            services.AddScoped<IOutletService, OutletService>();
            services.AddScoped<IDevicesServices, DevicesServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IPlaylistServices, PlaylistServices>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ITracksServices, TracksServices>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddScoped<ISharePointFileServices, SharePointFileServices>();

        }
    }
}
