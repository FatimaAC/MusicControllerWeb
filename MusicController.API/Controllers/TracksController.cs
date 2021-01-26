using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.PlaylistsServices;
using MusicController.BL.TrackServices;
using MusicController.Common.Enumerration;
using MusicController.DTO.APiResponesClass;
using MusicController.DTO.DTOModel;
using MusicController.DTO.ViewModel;
using MusicController.Identity.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.API.Controllers
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
        public TracksController(IPlaylistServices playlistServices, ITracksServices tracksServices , ICurrentUserService currentUserService , IMapper mapper)
        {
            _playlistServices = playlistServices;
            _currentUserService = currentUserService;
            _tracksServices = tracksServices;
            _mapper = mapper;
        }
     
        [HttpGet("WeeklySchedule")]
        public async Task<Response<WeeklyScheduleListDTO>> GetWeeklyScheduleList()
        {
            var outletId =Convert.ToInt64(_currentUserService.OutletId);
            var weeklyscheduleDTO = new WeeklyScheduleListDTO
            {
                WeeklyScheduleLists = await _playlistServices.WeeklyScheduleList(outletId)
            };
            if (weeklyscheduleDTO.WeeklyScheduleLists?.Any() != true)
            {
                return new Response<WeeklyScheduleListDTO>("No Playlist Found" ,StatusApiEnum.Success);
            }
            var tracks = await _tracksServices.GetTracksByOutletId(outletId);
            if (tracks!=null)
            {
                weeklyscheduleDTO.Tracks = _mapper.Map<List<TrackViewModel>>(tracks);
            }
            var response = new Response<WeeklyScheduleListDTO>(weeklyscheduleDTO);
            return response;
        }
    }
}
