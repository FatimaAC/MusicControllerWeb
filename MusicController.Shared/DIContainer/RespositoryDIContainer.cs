using Microsoft.Extensions.DependencyInjection;
using MusicController.Repository.DeviceRepository;
using MusicController.Repository.OutletsRepository;
using MusicController.Repository.UnitofWork;

namespace MusicController.Shared.DIContainer
{
    public static class RespositoryDIContainer
    {
        public static void RespositoryContainer(this IServiceCollection services)
        {
            services.AddScoped<IOutletRepository, OutletRepository>();
            services.AddScoped<IDevicesRepository, DevicesRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
        }
    }
}
