using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.TrackServices;
using MusicController.Common.Constants;
using MusicController.Common.HelperClasses;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using System;
using System.Threading.Tasks;

namespace MusicControllerWeb.Areas.Admin.Controllers
{
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.AdminorDJ)]
    public class TracksController : Controller
    {

        private readonly ITracksServices _tracksServices;
        private readonly IMapper _mapper;
        public TracksController(ITracksServices tracksServices, IMapper mapper)
        {
            _tracksServices = tracksServices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddTrack(TrackViewModel trackView)
        {
                trackView.StartTime = TimeSpanHelper.ShortTimeTo24HourFormat(trackView.FormatedStartTime);
                trackView.EndTime = TimeSpanHelper.ShortTimeTo24HourFormat(trackView.FormatedEndTime);
                if (trackView.StartTime>= trackView.EndTime)
                {
                    ModelState.AddModelError(string.Empty, "End time cannot be equal or less then start time");
                }
                if (ModelState.IsValid)
                {
                    var track = _mapper.Map<Track>(trackView);
                    await _tracksServices.AddTrack(track);
                  return RedirectToAction("Edit", "Playlist", new { id = trackView.PlaylistId, Area = UserRolesConstant.Admin });
                }

            return RedirectToAction("Edit", "Playlist", new { id = trackView.PlaylistId, Area = UserRolesConstant.Admin });
        }

        public async Task<IActionResult> Edit(long id)
        {
            var track = await _tracksServices.GetTrack(id);
            var tracViewModel = _mapper.Map<TrackViewModel>(track);
            //tracViewModel.FormatedStartTime = TimeSpanHelper.ShortTimeTo12HourFormat(tracViewModel.StartTime);
            //tracViewModel.FormatedEndTime = TimeSpanHelper.ShortTimeTo12HourFormat(tracViewModel.EndTime);
            return View(tracViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(long id, TrackViewModel trackViewModel)
        {
            //trackViewModel.StartTime = TimeSpanHelper.ShortTimeTo24HourFormat(trackViewModel.FormatedStartTime);
            //trackViewModel.EndTime = TimeSpanHelper.ShortTimeTo24HourFormat(trackViewModel.FormatedEndTime);
            if (trackViewModel.StartTime >= trackViewModel.EndTime)
            {
                ModelState.AddModelError(string.Empty, "End time cannot be equal or less then start time");
            }
            if (ModelState.IsValid)
                {
                    var track = _mapper.Map<Track>(trackViewModel);
                    await _tracksServices.UpdateTrack(id, track);
                    return RedirectToAction("Edit", "Playlist", new { id = trackViewModel.PlaylistId, Area = UserRolesConstant.Admin });
                }
            return RedirectToAction("Edit", "Playlist", new { id = trackViewModel.PlaylistId, Area = UserRolesConstant.Admin });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, long playlistId)
        {
            await _tracksServices.DeleteTrack(id);
            return RedirectToAction("Edit", "Playlist", new { id = playlistId, Area = UserRolesConstant.Admin });

        }
    }
}
