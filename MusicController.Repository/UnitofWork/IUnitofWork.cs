using MusicController.Entites.Models;
using MusicController.Repository.DeviceRepository;
using MusicController.Repository.GenericRepository;
using MusicController.Repository.OutletsRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Repository.UnitofWork
{
    public interface IUnitofWork
    {
         IDevicesRepository DeviceRepository { get; }
        IOutletRepository OutletRepository { get; }
        int Complete();
    }
}
