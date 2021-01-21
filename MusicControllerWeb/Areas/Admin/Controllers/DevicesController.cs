using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicController.BL.DevicesServices;
using MusicController.BL.OutletServices;
using MusicController.Common.Constants;
using MusicController.DTO.APiResponesClass;
using MusicController.DTO.ViewModel;
using MusicController.DTOModel.DTOS;
using MusicController.Entites.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MusicControllerWeb.Areas.Admin.Controllers
{
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.Admin)]
    public class DevicesController : Controller
    {
        private readonly IDevicesServices _devicesServices;
        private readonly IMapper _mapper;
        private readonly IOutletService _outletService;
        public DevicesController(IDevicesServices devicesServices, IMapper mapper, IOutletService outletService)
        {
            _devicesServices = devicesServices;
            _outletService = outletService;
            _mapper = mapper;
        }

        // GET: Admin/DeviceRegisterations
        public async Task<IActionResult> Index()
        {
            var deviceRegisterations = await _devicesServices.GetAllDevices();
            var deviceRegisterationsViewModel = _mapper.Map<List<DeviceViewModel>>(deviceRegisterations);
            return View(deviceRegisterationsViewModel);
        }

        // GET: Admin/DeviceRegisterations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceRegisteration = await _devicesServices.GetDevice(id.Value);
            if (deviceRegisteration == null)
            {
                return NotFound();
            }
            var deviceRegisterationsViewModel = _mapper.Map<DeviceViewModel>(deviceRegisteration);
            return View(deviceRegisterationsViewModel);
        }

        // GET: Admin/DeviceRegisterations/Create
        public async Task<IActionResult> Create()
        {
            ViewData["OutletId"] = new SelectList(await _outletService.GetAllOutlets(), "Id", "Name");
            return View();
        }

        // POST: Admin/DeviceRegisterations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OutletId,DeviceId,DeviceDetail,Password,StatusMessage")] DeviceViewModel deviceRegisterationViewModel)
        {
            if (ModelState.IsValid)
            {
                var deviceRegisterations = _mapper.Map<Device>(deviceRegisterationViewModel);
                await _devicesServices.AddDevice(deviceRegisterations);
                return RedirectToAction(nameof(Index));
            }
            ViewData["OutletId"] = new SelectList(await _outletService.GetAllOutlets(), "Id", "Name");
            return View(deviceRegisterationViewModel);
        }

        // POST: Admin/DeviceRegisterations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, DeviceDeleteViewModel devices)
        {
            if (id != devices.Id)
            {
                return NotFound();
            }
            await _devicesServices.DeleteDevice(id);
            return RedirectToAction("Edit", "Outlets", new { id = devices.OutletId, Area = UserRolesConstant.Admin });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveDevice(long id, DeviceDeleteViewModel devices)
        {
            if (id != devices.Id)
            {
                return NotFound();
            }
            await _devicesServices.ApproveDevice(id);
            return RedirectToAction("Edit", "Outlets", new { id = devices.OutletId, Area = UserRolesConstant.Admin });
        }
    }
}
