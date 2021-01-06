using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using MusicController.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            outlet.Password = "Welcome123$";
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
            outlet.Password = Password;
            outlet = EncryptPassword(outlet);
            _unitofWork.OutletRepository.UpdateEntity(outlet);
            _unitofWork.Complete();
        }

        private Outlet EncryptPassword(Outlet outlet)
        {
            outlet.Salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(outlet.Salt);
            }
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: outlet.Password,
                salt: outlet.Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            outlet.Password = hashed;
            return outlet;
        }
        private bool VerifyPassword(string enteredPassword, byte[] salt, string storedPassword)
        {
            string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return encryptedPassw == storedPassword;
        }
    }
}
