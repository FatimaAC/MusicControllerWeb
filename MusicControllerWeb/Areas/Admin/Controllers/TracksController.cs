using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.TrackServices;
using MusicController.Common.Constants;
using MusicController.Common.HelperClasses;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
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
            trackView.StartTime = DateTimeHelper.ShortTimeTo24HourFormat(trackView.FormatedStartTime);
            trackView.EndTime = DateTimeHelper.ShortTimeTo24HourFormat(trackView.FormatedEndTime);
            if (trackView.StartTime >= trackView.EndTime)
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
            ViewBag.OutletId = TempData.Peek("OutletId");
            var track = await _tracksServices.GetTrack(id);
            var trackViewModel = _mapper.Map<TrackViewModel>(track);
            return View(trackViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(long id, TrackViewModel trackViewModel)
        {
            var track = _mapper.Map<Track>(trackViewModel);
            if (track.StartTime >= track.EndTime)
            {
                ModelState.AddModelError(string.Empty, "End time cannot be equal or less then start time");
                return View(trackViewModel);
            }
            if (ModelState.IsValid)
            {
                await _tracksServices.UpdateTrack(id, track);
                return RedirectToAction("Edit", "Playlist", new { id = trackViewModel.PlaylistId, Area = UserRolesConstant.Admin });
            }
            return View(trackViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, long playlistId)
        {
            await _tracksServices.DeleteTrack(id);
            return RedirectToAction("Edit", "Playlist", new { id = playlistId, Area = UserRolesConstant.Admin });

        }
    }
}
