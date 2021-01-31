using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.DevicesServices;
using MusicController.BL.OutletServices;
using MusicController.Common.Constants;
using MusicController.DTO.ViewModel;
using MusicController.Shared.ExtensionMethod;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicControllerWeb.Areas.Admin.Controllers
{
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.AdminorDJ)]
    public class DevicesController : Controller
    {
        private readonly IDevicesServices _devicesServices;
        private readonly IMapper _mapper;
        public DevicesController(IDevicesServices devicesServices, IMapper mapper)
        {
            _devicesServices = devicesServices;
            _mapper = mapper;
        }
        // GET: Admin/Devices
        public async Task<IActionResult> Index()
        {
            var deviceRegisterations = await _devicesServices.GetAllDevices();
            var deviceRegisterationsViewModel = _mapper.Map<List<DeviceViewModel>>(deviceRegisterations);
            return View(deviceRegisterationsViewModel);
        }

        // POST: Admin/Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, DeviceDeleteViewModel devices)
        {
            if (id != devices.Id)
            {
                return NotFound();
            }
            await _devicesServices.DeleteDevice(id);
            if (devices.ReturnToDevices)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Edit", "Outlets", new { id = devices.OutletId, Area = UserRolesConstant.Admin });
        }
        // POST: Admin/Devices/ApproveDevice/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveDevice(long id, DeviceDeleteViewModel devices)
        {
            if (id != devices.Id)
            {
                return NotFound();
            }
            await _devicesServices.ApproveDevice(id);
            if (devices.ReturnToDevices)
            {
                return RedirectToAction(nameof(Index));
            }
            return  RedirectToAction("Edit", "Outlets", new { id = devices.OutletId, Area = UserRolesConstant.Admin });
        }
    }
}
