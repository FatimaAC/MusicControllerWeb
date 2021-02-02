using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicController.Common.HelperClasses;
using MusicController.Shared.CrosSetting;
using MusicController.Shared.DIContainer;
using MusicController.Shared.ExpectionHelper;
using MusicController.Shared.Identity;
using Serilog;
using System.IO;

namespace MusicController.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.CorsContainer();
            services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()
            ));
            services.DBContainer(Configuration);
            services.RespositoryContainer();
            services.ServicesContainer();
            services.MapperContainer();
            services.SwaggerContainer();
            services.IdentityContainer();
            services.TokenContainer();
            services.UseApiValidationHandler();
            
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSerilogRequestLogging();
            // Customized Authroized Response
            app.CustomUnauthorized();
            // Customized Expection
            app.UseApiExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.CorsContainer();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            // Swagger Setting
            app.SwaggerRouting();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
