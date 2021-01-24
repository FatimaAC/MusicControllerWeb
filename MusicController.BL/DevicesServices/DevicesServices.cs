using MusicController.Common.HelperClasses;
using MusicController.Entites.Models;
using MusicController.Identity.UserService;
using MusicController.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.BL.DevicesServices
{
    public class DevicesServices : IDevicesServices
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ICurrentUserService _currentUserService;
        public DevicesServices(IUnitofWork unitofWork, ICurrentUserService currentUserService)
        {
            _unitofWork = unitofWork;
            _currentUserService = currentUserService;
        }

        public async Task AddDevice(Device device)
        {

            if (await _unitofWork.DeviceRepository.AnyAsync(e => e.DeviceId == device.DeviceId))
            {
                throw new Exception("Device is already Assigned");
            }
            await _unitofWork.DeviceRepository.AddAsync(device);
            _unitofWork.Complete();
        }

        public async Task RegisterDevice(Device device , string password)
        {
            var outletPassword =await _unitofWork.OutletRepository.GetAsync(device.OutletId);
            var verifyPassword = PasswordHelper.VerifyPassword(password, outletPassword.Password);
            if (!verifyPassword)
            {
                throw new Exception("Password do not Match");
            }
            await AddDevice(device);
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

        public async Task<List<Device>> GetDevicesByOutlet(long outletId)
        {
            var devices = await _unitofWork.DeviceRepository.FindAllAsync(e=>e.OutletId== outletId);
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
                throw new Exception("Device not Found");
            }
            devices.DeviceId = outlet.DeviceId;
            devices.OutletId = outlet.OutletId;
            _unitofWork.DeviceRepository.UpdateEntity(devices);
            _unitofWork.Complete();
        }

        public async Task UpdateDeviceStatus(Device device)
        {
            var UpdateDevice = await _unitofWork.DeviceRepository.SingleOrDefaultAsync(e => e.DeviceId == device.DeviceId);
            if (UpdateDevice == null)
            {
                throw new Exception("Device not Found");
            }
            UpdateDevice.StatusMessage = device.StatusMessage;
            UpdateDevice.StatusPostedAt = device.StatusPostedAt;
             _unitofWork.DeviceRepository.UpdateEntity(UpdateDevice);
            _unitofWork.Complete();
        }
        public async Task ApproveDevice(long id)
        {
            var device = await GetDevice(id);
            device.IsApproved = true;
            device.ApprovedBy = _currentUserService.UserId;
            _unitofWork.DeviceRepository.UpdateEntity(device);
            _unitofWork.Complete();
        }
    }
}
