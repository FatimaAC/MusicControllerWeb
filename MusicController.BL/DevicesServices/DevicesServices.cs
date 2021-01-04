using MusicController.Entites.Models;
using MusicController.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicController.BL.DevicesServices
{
    public class DevicesServices : IDevicesServices
    {
        private readonly IUnitofWork _unitofWork;
        public DevicesServices(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task AddDevice(Device device)
        {
            await _unitofWork.DeviceRepository.AddAsync(device);
            _unitofWork.Complete();
        }

        public async Task DeleteDevice(long id)
        {
            var device = await _unitofWork.DeviceRepository.GetAsync(id);
            if (device == null)
            {
                throw new Exception("Not Found");
            }
            _unitofWork.DeviceRepository.Remove(device);
            _unitofWork.Complete();
        }

        public async Task<List<Device>> GetAllDevices()
        {
            var devices = await _unitofWork.DeviceRepository.GetDeviceWithOutlets();
            return devices.ToList();
        }

        public async Task<Device> GetDevice(long id)
        {
            var devices = await _unitofWork.DeviceRepository.GetAsync(id);
            if (devices == null)
            {
                throw new Exception("Id not Found");
            }
            return devices;
        }

        public async Task UpdateDevice(long id, Device outlet)
        {
            var devices = await _unitofWork.DeviceRepository.GetAsync(id);
            if (devices == null)
            {
                throw new Exception("Id not Found");
            }
            devices.DeviceId = outlet.DeviceId;
            devices.OutletId = outlet.OutletId;
            _unitofWork.DeviceRepository.UpdateEntity(devices);
            _unitofWork.Complete();
        }
    }
}
