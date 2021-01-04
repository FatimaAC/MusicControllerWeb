using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using MusicController.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicController.BL.OutletServices
{
    public class OutletService : IOutletService
    {
        private readonly IUnitofWork _unitofWork;
        public OutletService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
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

        public async Task UpdateOutlet(long id, Outlet outlet)
        {
            var outletObj = await _unitofWork.OutletRepository.GetAsync(id);
            if (outletObj == null)
            {
                throw new Exception("Id not Found");
            }
            outletObj.Name = outlet.Name;
            outletObj.Description = outlet.Description;
            _unitofWork.OutletRepository.UpdateEntity(outletObj);
            _unitofWork.Complete();
        }
    }
}
