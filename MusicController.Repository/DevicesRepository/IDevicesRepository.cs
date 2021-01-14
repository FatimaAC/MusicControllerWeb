using MusicController.Entites.Models;
using MusicController.Repository.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.Repository.DeviceRepository
{
    public interface IDevicesRepository : IGenericRepository<Device>
    {
        Task<IEnumerable<Device>> GetDeviceWithOutlets();
        Task<Device> GetOutletWithDevice(string deviceId, long outletId);
    }
}
