using AutoMapper;
using MusicController.Common.HelperClasses;
using MusicController.DTO.RequestModel;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using MusicController.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.BL.OutletServices
{
    public class OutletService : IOutletService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        public OutletService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task AddOutlet(Outlet outlet)
        {

            //var passwordandSalt =  outlet.Password.EncryptPassword();
            //outlet.Password = passwordandSalt.Item1;
            //outlet.Salt = passwordandSalt.Item2;
            await _unitofWork.OutletRepository.AddAsync(outlet);
            _unitofWork.Complete();
        }

        public async Task DeleteOutlet(long id)
        {
            var outlet = await _unitofWork.OutletRepository.GetAsync(id);
            if (outlet == null)
            {
                throw new Exception("Not Found");
            }
            _unitofWork.OutletRepository.Remove(outlet);
            _unitofWork.Complete();
        }

        public async Task<List<Outlet>> GetAllOutlets()
        {
            var outletViewModel = await _unitofWork.OutletRepository.GetAllAsync();
            return outletViewModel.ToList();
        }
        public async Task<List<OutletViewModel>> GetAllOutletsWithDevicesAndPlaylist()
        {
            var outletViewModel = await _unitofWork.OutletRepository.GetAllWithDevices();
            return outletViewModel.ToList();
        }

        public async Task<Outlet> GetOutlet(long id)
        {
            var outlet = await _unitofWork.OutletRepository.GetAsync(id);
            if (outlet == null)
            {
                throw new Exception("Id not Found");
            }
            return outlet;
        }


        public async Task<OutletManageViewModel> ManageOutletsWithDevicesandPassword(long id)
        {
            OutletManageViewModel outletManageViewModel = new OutletManageViewModel();
            var outlet = await GetOutlet(id);
            if (outlet == null)
            {
                throw new Exception("Record not found");
            }
            var devices = await _unitofWork.DeviceRepository.FindAllAsync(e => e.OutletId == outlet.Id);
            outletManageViewModel.Outlet = _mapper.Map<OutletCreateViewModel>(outlet);
            outletManageViewModel.Devices = _mapper.Map<List<DeviceViewModel>>(devices.ToList());
            outletManageViewModel.OutletPasswords = _mapper.Map<OutletPasswordsViewModel>(outlet);
            return outletManageViewModel;
        }
        public async Task UpdateOutlet(long id, Outlet outlet)
        {
            var outletObj = await _unitofWork.OutletRepository.GetAsync(id);
            if (outletObj == null)
            {
                throw new Exception("Id not Found");
            }
            outletObj.Name = outlet.Name;
            outletObj.ImageUrl = outlet.ImageUrl;
            _unitofWork.OutletRepository.UpdateEntity(outletObj);
            _unitofWork.Complete();
        }

        public async Task UpdatePasswordOutlet(long id, string Password)
        {
            var outlet = await _unitofWork.OutletRepository.GetAsync(id);
            if (outlet == null)
            {
                throw new Exception("Id not Found");
            }
             outlet.Password = PasswordHelper.EncryptPassword(Password);
            //outlet.Password = passwordandSalt.Item1;
            //outlet.Salt = passwordandSalt.Item2;
            _unitofWork.OutletRepository.UpdateEntity(outlet);
            _unitofWork.Complete();
        }


        public async Task ValidateOutletandDevice(LoginRequest loginRequest)
        {
            if (!await _unitofWork.OutletRepository.AnyAsync(e=>e.Id==loginRequest.OutletId))
            {
                throw new Exception("Outlet Not found");
            }
            var outletwithDevice =await _unitofWork.DeviceRepository.GetOutletWithDevice(loginRequest.DeviceId, loginRequest.OutletId);
            
            if (outletwithDevice == null)
            {
                throw new Exception("No device Register yet");
            }
            if (!outletwithDevice.IsApproved)
            {
                throw new Exception("Waiting for Authorization");
            }
            var outlet = outletwithDevice.Outlet;
            var verifyPassword = PasswordHelper.VerifyPassword(loginRequest.Password,outlet.Password);
            if (!verifyPassword)
            {
                throw new Exception("Password do not match");
            }
            var PlayListWithTrack = _unitofWork.PlaylistRepository.FindAllAsync(e => e.OutletId == loginRequest.OutletId);
        }

    }
}
