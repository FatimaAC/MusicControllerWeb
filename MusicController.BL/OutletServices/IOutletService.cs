using MusicController.DTO.RequestModel;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.BL.OutletServices
{
    public interface IOutletService
    {
        Task<List<Outlet>> GetAllOutlets();
        Task<List<OutletViewModel>> GetAllOutletsWithDevicesAndPlaylist();

        Task<OutletManageViewModel> ManageOutletsWithDevicesandPassword(long id);
        Task AddOutlet(Outlet outlet);
        Task UpdateOutlet(long id, Outlet outlet);
        Task UpdatePasswordOutlet(long id, string Password);
        Task<Outlet> GetOutlet(long id);
        Task DeleteOutlet(long id);
        Task<bool> ValidateOutletandDevice(LoginRequest loginRequest);
    }
}
