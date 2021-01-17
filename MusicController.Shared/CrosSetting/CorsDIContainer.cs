using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MusicController.Shared.CrosSetting
{
    public static class CorsDIContainer
    {
        public static void CorsContainer(this IApplicationBuilder app)
        {
           // services.AddCors(options =>
           //{
           //    options.AddDefaultPolicy(
           //        builder =>
           //        {
           //            builder.WithOrigins("http://localhost:5000").AllowAnyHeader().AllowAnyMethod();
           //        });
           //});

            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

        }

    }
}
