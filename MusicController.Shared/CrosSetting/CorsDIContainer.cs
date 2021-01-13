using Microsoft.Extensions.DependencyInjection;

namespace MusicController.Shared.CrosSetting
{
    public static class CorsDIContainer
    {
        public static void CorsContainer(this IServiceCollection services)
        {
            services.AddCors(options =>
           {
               options.AddDefaultPolicy(
                   builder =>
                   {
                       builder.WithOrigins("http://localhost:5000").AllowAnyHeader().AllowAnyMethod();
                   });
           });

        }

    }
}
