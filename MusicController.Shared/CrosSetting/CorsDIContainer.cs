using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MusicController.Shared.CrosSetting
{
    public static class CorsDIContainer
    {
        private const string CorsPolicy = "AllowAll";
        // Todo : Added your Application Policy
        public static void CorsContainer(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder =>
                    {
                        builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                    .SetIsOriginAllowed(hostName => true);
                    });
            });
        }
        public static void CorsContainer(this IApplicationBuilder app)
        {
            app.UseCors(CorsPolicy);
        }
    }
}
