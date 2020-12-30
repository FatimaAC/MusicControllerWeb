using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicController.Identity.IdentityContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Shared.DIContainer
{
    public static class DBDIContainer
    {
        public static void DBContainer(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
        }
    }
}
