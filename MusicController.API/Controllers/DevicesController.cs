﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.DevicesServices;
using MusicController.BL.OutletServices;
using MusicController.DTO.RequestModel;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesServices _devicesServices;
        private readonly IMapper _mapper;
        public DevicesController(IDevicesServices devicesServices, IMapper mapper)
        {
            _devicesServices = devicesServices;
            _mapper = mapper;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostDevice([FromBody] DevicesRequest devicesRequest)
        {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var device = _mapper.Map<Device>(devicesRequest);
                await _devicesServices.AddDevice(device);
                return NoContent();
        }
    }
}
