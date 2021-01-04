using MusicController.Entites.Context;
using MusicController.Entites.Models;
using MusicController.Repository.DeviceRepository;
using MusicController.Repository.GenericRepository;
using MusicController.Repository.OutletsRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Repository.UnitofWork
{
   public class UnitofWork : IUnitofWork
    {
        private readonly MusicDBContext _musicDBContext;

        public UnitofWork(MusicDBContext musicDBContext)
        {
            _musicDBContext = musicDBContext;
            OutletRepository = new OutletRepository(_musicDBContext);
            DeviceRepository = new DevicesRepository(_musicDBContext);
        }
       public IDevicesRepository DeviceRepository { get; private set; }
       public IOutletRepository OutletRepository { get; private set; }
        public int Complete()
        {
            return _musicDBContext.SaveChanges();
        }
        public void Dispose()
        {
            _musicDBContext.Dispose();
        }
    }
}
