using Microsoft.EntityFrameworkCore;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Context;
using MusicController.Entites.Models;
using MusicController.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.Repository.OutletsRepository
{
    public class OutletRepository : GenericRepository<Outlet>, IOutletRepository
    {
        private readonly MusicDBContext _musicDbContext;

        public OutletRepository(MusicDBContext musicDbContext) : base(musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public async Task<IEnumerable<OutletViewModel>> GetAllWithDevices()
        {
            var outlets = await _musicDbContext.Outlets
                                .Include(e => e.Devices)
                                .Include(e => e.Playlist).Select(s => new OutletViewModel
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    LogoUrl = s.ImageUrl,
                                    TotalDevices = s.Devices.Count(),
                                    TotalPlaylists = s.Playlist.Count(),
                                }).ToListAsync();

            return outlets;
        }
        
        public Task<IEnumerable<Outlet>> GetOutletByAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Outlet>> GetOutletByDJ()
        {
            throw new NotImplementedException();
        }
    }
}
