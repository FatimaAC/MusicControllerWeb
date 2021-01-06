using MusicController.Repository.DeviceRepository;
using MusicController.Repository.OutletsRepository;

namespace MusicController.Repository.UnitofWork
{
    public interface IUnitofWork
    {
        IDevicesRepository DeviceRepository { get; }
        IOutletRepository OutletRepository { get; }
        int Complete();
    }
}
