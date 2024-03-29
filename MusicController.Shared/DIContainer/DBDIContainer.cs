﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicController.Entites.Context;
using MusicController.Identity.IdentityContext;

namespace MusicController.Shared.DIContainer
{
    // Database Reigstraion for Web and APi 
    public static class DBDIContainer
    {
        public static void DBContainer(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            services.AddDbContext<MusicDBContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);



        }
    }
}
