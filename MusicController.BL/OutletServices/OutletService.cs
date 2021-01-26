using AutoMapper;
using MusicController.Common.HelperClasses;
using MusicController.DTO.RequestModel;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using MusicController.Repository.UnitofWork;
using MusicController.Shared.ExpectionHelper;
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
            await _unitofWork.OutletRepository.AddAsync(outlet);
            _unitofWork.Complete();
        }

        public async Task DeleteOutlet(long id)
        {
            var outlet = await _unitofWork.OutletRepository.GetAsync(id);
            if (outlet == null)
            {
                throw new UserFriendlyException(" Record not found");
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
                throw new UserFriendlyException("Record not found", 1);
            }
            return outlet;
        }

        public async Task<OutletManageViewModel> ManageOutletsWithDevicesandPassword(long id)
        {
            OutletManageViewModel outletManageViewModel = new OutletManageViewModel();
            var outlet = await GetOutlet(id);
            if (outlet == null)
            {
                throw new UserFriendlyException("Record not found" ,1 );
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
                throw new UserFriendlyException("Record not found");
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
                throw new UserFriendlyException("Id not Found");
            }
             outlet.Password = PasswordHelper.EncryptPassword(Password);
            //outlet.Password = passwordandSalt.Item1;
            //outlet.Salt = passwordandSalt.Item2;
            _unitofWork.OutletRepository.UpdateEntity(outlet);
            _unitofWork.Complete();
        }


        public async Task ValidateOutletandDevice(LoginRequest loginRequest)
        {
            var outlet = await GetOutlet(loginRequest.OutletId);
            if (outlet==null)
            {
                throw new UserFriendlyException("Outlet Not found" ,1);
            }
            var verifyPassword = PasswordHelper.VerifyPassword(loginRequest.Password, outlet.Password);
            if (!verifyPassword)
            {
                throw new UserFriendlyException("Password do not match", 1);
            }
            var outletwithDevice =await _unitofWork.DeviceRepository.GetOutletWithDevice(loginRequest.DeviceId, loginRequest.OutletId);
            
            if (outletwithDevice == null)
            {
                throw new UserFriendlyException("No device Register yet" ,2);
            }
            if (!outletwithDevice.IsApproved)
            {
                throw new UserFriendlyException("Waiting for Authorization" ,3);
            }
            var PlayListWithTrack = _unitofWork.PlaylistRepository.FindAllAsync(e => e.OutletId == loginRequest.OutletId);
        }

    }
}
