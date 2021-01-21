using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.DevicesServices;
using MusicController.BL.FileServices;
using MusicController.BL.OutletServices;
using MusicController.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicControllerWeb.Components.EditOutlet
{
    public class OutletDevicesViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IDevicesServices _devicesServices;
        public OutletDevicesViewComponent(IMapper mapper, IDevicesServices devicesServices)
        {
            _devicesServices = devicesServices;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(long OutletId)
        {
            var devices = await _devicesServices.GetDevicesByOutlet(OutletId);
            var deviceViewModel = _mapper.Map<List<DeviceViewModel>>(devices);
            return View("OutletDevices", deviceViewModel);
        }
    }
}
