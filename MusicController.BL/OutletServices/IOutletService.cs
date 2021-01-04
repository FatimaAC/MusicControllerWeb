using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicController.BL.OutletServices
{
   public interface IOutletService 
    {
        Task<List<Outlet>> GetAllOutlets();
        Task<List<OutletViewModel>> GetAllOutletsWithDevicesAndPlaylist();
        Task AddOutlet(Outlet outlet);
        Task UpdateOutlet(long id, Outlet outlet);
        Task<Outlet> GetOutlet(long id);
        Task DeleteOutlet(long id);
    }
}
