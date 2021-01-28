using AutoMapper;
using MusicController.Common.Enumerration;
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
                throw new UserFriendlyException(" Record not found" , StatusApiEnum.Failure);
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
                throw new UserFriendlyException("Record not found", StatusApiEnum.Failure);
            }
            return outlet;
        }

        public async Task<OutletManageViewModel> ManageOutletsWithDevicesandPassword(long id)
        {
            OutletManageViewModel outletManageViewModel = new OutletManageViewModel();
            var outlet = await GetOutlet(id);
            if (outlet == null)
            {
                throw new UserFriendlyException("Record not found" , StatusApiEnum.Failure);
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
                throw new UserFriendlyException("Record not found" , StatusApiEnum.Failure);
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
                throw new UserFriendlyException("Record not Found" , StatusApiEnum.Failure);
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
                throw new UserFriendlyException("Record Not found" , StatusApiEnum.Failure);
            }
            var verifyPassword = PasswordHelper.VerifyPassword(loginRequest.Password, outlet.Password);
            if (!verifyPassword)
            {
                throw new UserFriendlyException("Wrong Password", StatusApiEnum.Failure);
            }
            var outletwithDevice =await _unitofWork.DeviceRepository.GetOutletWithDevice(loginRequest.DeviceId, loginRequest.OutletId);
            
            if (outletwithDevice == null)
            {
                var outletForName = await _unitofWork.OutletRepository.GetOutletByDevice(loginRequest.DeviceId);
                if (outletForName != null)
                {
                    throw new UserFriendlyException($"Wrong Outlet selected, You are trying to log into {outlet.Name} but you are registered to {outletForName.Name}" , StatusApiEnum.AlreadyAssignedDevice);
                }
                throw new UserFriendlyException("No device Register yet" , StatusApiEnum.NotRegister);
            }
            if (!outletwithDevice.IsApproved)
            {
                throw new UserFriendlyException("Waiting for approval", StatusApiEnum.RequriedApproval);
            }
            var PlayListWithTrack = _unitofWork.PlaylistRepository.FindAllAsync(e => e.OutletId == loginRequest.OutletId);
        }
    }
}
