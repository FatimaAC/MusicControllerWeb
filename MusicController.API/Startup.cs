using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicController.Shared.DIContainer;
using MusicController.Shared.ExpectionHelper;
using MusicController.Shared.Identity;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddControllers();
            services.DBContainer(Configuration);
            services.RespositoryContainer();
            services.ServicesContainer();
            services.MapperContainer();
            services.AddSwaggerGen();
            services.IdentityContainer();
            services.TokenContainer();
            services.UseApiValidationHandler();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseApiExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.SwaggerRouting();
        }
    }
}
