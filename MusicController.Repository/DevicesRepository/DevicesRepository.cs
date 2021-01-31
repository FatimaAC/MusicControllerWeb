using Microsoft.EntityFrameworkCore;
using MusicController.Entites.Context;
using MusicController.Entites.Models;
using MusicController.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
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
            var outlets = await _musicDbContext.Device.Include(e => e.Outlet).OrderBy(e => e.Outlet.Name).ToListAsync();
            return outlets;
        }
        public async Task<Device> GetOutletWithDevice(string deviceId, long outletId)
        {
            var outletwithDevices = await _musicDbContext.Device
                                    .Include(e => e.Outlet)
                                    .Where(e => e.DeviceId == deviceId && e.Outlet.Id == outletId)
                                     .FirstOrDefaultAsync();
            return outletwithDevices;
        }

    }
}
