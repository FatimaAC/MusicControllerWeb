using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MusicController.Shared.CrosSetting
{
    public static class CorsDIContainer
    {
        public static void CorsContainer(this ServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

        }

        public static void CorsContainer(this IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
        }

    }
}
