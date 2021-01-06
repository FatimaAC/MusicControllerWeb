using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using MusicController.BL.DevicesServices;
using MusicController.BL.FileServices;
using MusicController.BL.OutletServices;
using MusicController.Identity.IdentityUserManagement;
using MusicController.Identity.UserService;
using MusicController.Shared.ExtensionMethod;

namespace MusicController.Shared.DIContainer
{
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
            services.AddScoped<IOutletService, OutletService>();
            services.AddScoped<IDevicesServices, DevicesServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
        }
    }
}
