using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using MusicController.Repository.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.Repository.OutletsRepository
{
    public interface IOutletRepository : IGenericRepository<Outlet>
    {
        Task<IEnumerable<OutletViewModel>> GetAllWithDevices();
    }
}
