using Microsoft.Extensions.DependencyInjection;
using MusicController.BL.DevicesServices;
using MusicController.BL.FileServices;
using MusicController.BL.OutletServices;
using MusicController.Identity.IdentityUserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Shared.DIContainer
{
    public static class ServicesDIContainer
    {
        public static void ServicesContainer(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserServices, ApplicationUserServices>();
            services.AddScoped<IOutletService, OutletService>();
            services.AddScoped<IDevicesServices, DevicesServices>();
            services.AddScoped<IFileServices, FileServices>();
            
        }
    }
}
