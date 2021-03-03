using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicController.Entites.Context;
using MusicController.Identity.IdentityContext;
using MusicController.Shared;
using MusicController.Shared.DIContainer;
using MusicController.Shared.Identity;
using Microsoft.Extensions.Logging;

using MusicController.Common.HelperClasses;
using MusicController.Shared.CrosSetting;
using MusicController.Shared.ExpectionHelper;
using Serilog;
using System.IO;

namespace MusicControllerWeb
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration , IHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile(Utility.EnvironmentFile(), optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.CorsContainer();
            services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()
            ));

            // DI containter for services ,databases and automapper
            services.DBContainer(Configuration);
            services.RespositoryContainer();
            services.ServicesContainer();
            services.MapperContainer();
            services.IdentityContainer();
            services.IdentityCookieSetting();
            services.AddControllersWithViews()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/{0}.cshtml");
                })
                   .AddRazorRuntimeCompilation()
                   .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddRazorPages();
            services.SwaggerContainer();

            services.UseApiValidationHandler();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                // applicationDbContext.Database.Migrate();
                // musicDBContext.Database.Migrate();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseHsts();
            }
            //app.UseSerilogRequestLogging();
            // Customized Authroized Response
            //app.CustomUnauthorized();
            // Customized Expection
            app.UseApiExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //todo: set Defualt route to the Admin outlets 
                endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
                endpoints.MapControllerRoute(
                    name: "default",
                   pattern: "{area=Admin}/{controller=Outlets}/{action=Index}/{id?}"
                   );
                endpoints.MapRazorPages();
            });
        }
    }
}
