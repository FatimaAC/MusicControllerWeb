using Microsoft.EntityFrameworkCore;
using MusicController.Entites.Context;
using MusicController.Entites.Models;
using MusicController.Repository.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.Repository.DeviceRepository
{
    public class DevicesRepository : GenericRepository<Device>, IDevicesRepository
    {
        private readonly MusicDBContext _musicDbContext;

        public DevicesRepository(MusicDBContext musicDbContext) : base(musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public async Task<IEnumerable<Device>> GetDeviceWithOutlets()
        {
            var outlets = await _musicDbContext.Device.Include(e => e.Outlet).ToListAsync();
            return outlets;
        }
    }
}
