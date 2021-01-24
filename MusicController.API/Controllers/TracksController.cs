using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.PlaylistsServices;
using MusicController.DTO.APiResponesClass;
using MusicController.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly IPlaylistServices _tracksServices;
        public TracksController(IPlaylistServices tracksServices)
        {
            _tracksServices = tracksServices;
        }
        [Authorize]
        [HttpGet("WeeklySchedule/{outletId}")]
        public async Task<Response<List<WeeklyScheduleList>>> GetWeeklyScheduleList([FromRoute] long outletId)
        {
            var weeklyScheduleList = await _tracksServices.WeeklyScheduleList(outletId);
            var ScheduleList = await _tracksServices.WeeklyScheduleList(outletId);
            var response = new Response<List<WeeklyScheduleList>>(weeklyScheduleList);
            return response;
        }
    }
}
