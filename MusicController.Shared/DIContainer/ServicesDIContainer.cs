using Microsoft.Extensions.DependencyInjection;
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
            //.AddScoped<applictionrole, ApplicationRolesMangement>();
        }
    }
}
