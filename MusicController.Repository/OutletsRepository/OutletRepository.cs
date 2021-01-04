﻿using Microsoft.EntityFrameworkCore;
using MusicController.Entites.Context;
using MusicController.Entites.Models;
using MusicController.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MusicController.DTO.ViewModel;

namespace MusicController.Repository.OutletsRepository
{
   public class OutletRepository :  GenericRepository<Outlet>, IOutletRepository
    {
        private readonly MusicDBContext _musicDbContext;

        public OutletRepository(MusicDBContext musicDbContext) : base(musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public async Task<IEnumerable<OutletViewModel>> GetAllWithDevices(){
            var outlets = await _musicDbContext.Outlets
                                .Include(e => e.Devices)
                                .Include(e => e.Playlist).Select(s=>new OutletViewModel {
                                    Id =s.Id,
                                    Name = s.Name,
                                    LogoUrl = s.ImageUrl,
                                    TotalDevices = s.Devices.Count(),
                                    TotalPalylist = s.Playlist.Count(),
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
