using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.DevicesServices;
using MusicController.Common.Enumerration;
using MusicController.DTO.APiResponesClass;
using MusicController.DTO.RequestModel;
using MusicController.Entites.Models;
using MusicController.Identity.UserService;
using System.Threading.Tasks;

namespace MusicController.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesServices _devicesServices;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public DevicesController(IDevicesServices devicesServices, ICurrentUserService currentUserService, IMapper mapper)
        {
            _devicesServices = devicesServices;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        [HttpPost("RegisterDevice")]
        [AllowAnonymous]
        public async Task<IActionResult> PostDevice([FromBody] DevicesRequest devicesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var device = _mapper.Map<Device>(devicesRequest);
            await _devicesServices.RegisterDevice(device, devicesRequest.Password);
            var response = new Response<string>("Device added successfully", StatusApiEnum.Success);
            return Ok(response);
        }
        [HttpPost("DeviceStatus")]
        public async Task<IActionResult> PostDeviceStatus([FromBody] DeviceStatusRequest deviceStatus)
        {
            deviceStatus.DeviceId = _currentUserService.DeviceId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var device = _mapper.Map<Device>(deviceStatus);
            await _devicesServices.UpdateDeviceStatus(device);
            var response = new Response<string>("Device status added successfully", StatusApiEnum.Success);
            return Ok(response);
        }
    }
}
