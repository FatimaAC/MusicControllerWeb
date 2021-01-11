using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicController.Entites.Context;
using MusicController.Identity.IdentityContext;
using MusicController.Identity.Model;
using MusicController.Shared;
using MusicController.Shared.DIContainer;

namespace MusicControllerWeb
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IHostEnvironment HostingEnvironment;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // inject appsetting file according to the environment
        public Startup(IHostEnvironment env)
        {
            HostingEnvironment = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(Utility.EnvironmentFile(), optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DI containter for services ,databases and automapper
            services.DBContainer(Configuration);
            services.RespositoryContainer();
            services.ServicesContainer();
            services.MapperContainer();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,MusicDBContext musicDBContext ,ApplicationDbContext applicationDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                applicationDbContext.Database.Migrate();
                musicDBContext.Database.Migrate();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

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
                   // pattern: "{controller=Home}/{action=Index}/{id?}"
                   pattern: "{area=Admin}/{controller=Outlets}/{action=Index}/{id?}"
                   );
                endpoints.MapRazorPages();
            });
        }
    }
}
