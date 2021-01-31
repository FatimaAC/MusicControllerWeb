using Microsoft.Extensions.DependencyInjection;
using MusicController.Entites.Models;
using MusicController.Repository.DeviceRepository;
using MusicController.Repository.GenericRepository;
using MusicController.Repository.OutletsRepository;
using MusicController.Repository.PlaylistsRepository;
using MusicController.Repository.UnitofWork;

namespace MusicController.Shared.DIContainer
{
    // Repositoty and Unit of work Reigstraion for Web and APi 
    public static class RespositoryDIContainer
    {
        public static void RespositoryContainer(this IServiceCollection services)
        {
            services.AddScoped<IOutletRepository, OutletRepository>();
            services.AddScoped<IDevicesRepository, DevicesRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IGenericRepository<Track>, GenericRepository<Track>>();
            services.AddScoped<IUnitofWork, UnitofWork>();
        }
    }
}
