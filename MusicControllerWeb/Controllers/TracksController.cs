using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.PlaylistsServices;
using MusicController.BL.TrackServices;
using MusicController.Common.Enumerration;
using MusicController.DTO.APiResponesClass;
using MusicController.DTO.ViewModel;
using MusicController.Identity.UserService;
using System;
using System.Threading.Tasks;

namespace MusicControllerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TracksController : ControllerBase
    {
        private readonly IPlaylistServices _playlistServices;
        private readonly ITracksServices _tracksServices;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public TracksController(IPlaylistServices playlistServices, ITracksServices tracksServices, ICurrentUserService currentUserService, IMapper mapper)
        {
            _playlistServices = playlistServices;
            _currentUserService = currentUserService;
            _tracksServices = tracksServices;
            _mapper = mapper;
        }

        [HttpGet("TodaySchedulePlaylist")]
        public async Task<Response<WeeklyScheduleList>> TodaySchedulePlaylist()
        {
            var outletId = Convert.ToInt64(_currentUserService.OutletId);
            var todayPlaylist = await _playlistServices.TodaySchedulePlaylist(outletId);
            if (todayPlaylist == null)
            {
                return new Response<WeeklyScheduleList>("No playlist found", StatusApiEnum.Empty);
            }
            var response = new Response<WeeklyScheduleList>(todayPlaylist);
            return response;
        }
    }
}
