using MusicController.Entites.Models;
using MusicController.Repository.DeviceRepository;
using MusicController.Repository.GenericRepository;
using MusicController.Repository.OutletsRepository;
using MusicController.Repository.PlaylistsRepository;

namespace MusicController.Repository.UnitofWork
{
    public interface IUnitofWork
    {
        IDevicesRepository DeviceRepository { get; }
        IOutletRepository OutletRepository { get; }
        IPlaylistRepository PlaylistRepository { get; }
        IGenericRepository<Track> TrackRepository { get; }
        int Complete();
    }
}
