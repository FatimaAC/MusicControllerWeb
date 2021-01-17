using MusicController.Entites.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.BL.DevicesServices
{
    public interface IDevicesServices
    {
        Task<List<Device>> GetAllDevices();
        Task AddDevice(Device device);
        Task UpdateDevice(long id, Device device);
        Task<Device> GetDevice(long id);
        Task DeleteDevice(long id);
        Task ApproveDevice(long id);
        Task RegisterDevice(Device device, string password);
    }
}
