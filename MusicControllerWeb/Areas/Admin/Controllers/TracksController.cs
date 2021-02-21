using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.SharePointFiles;
using MusicController.BL.TrackServices;
using MusicController.Common.Constants;
using MusicController.Common.HelperClasses;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using System.Linq;
using System.Threading.Tasks;
 
namespace MusicControllerWeb.Areas.Admin.Controllers
{
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.AdminorDJ)]
    public class TracksController : Controller
    {

        private readonly ITracksServices _tracksServices;
        private readonly IMapper _mapper;
        private readonly ISharePointFileServices _SPfileServices;
        private readonly string[] _validExtensions = { ".mp3", ".mp4", ".wmv", ".mov", ".AVI" };
 
        public TracksController(ISharePointFileServices SPFileService, IMapper mapper, ITracksServices tracksServices)
        {
            _tracksServices = tracksServices;
            _mapper = mapper;
            _SPfileServices = SPFileService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTrack(TrackViewModel trackView)
        {
            trackView.StartTime = DateTimeHelper.ShortTimeTo24HourFormat(trackView.FormatedStartTime);
            trackView.EndTime = DateTimeHelper.ShortTimeTo24HourFormat(trackView.FormatedEndTime);
            trackView.TrackURL = "http://78.100.122.178:6040/playlists/" + trackView.File.FileName;

            if (trackView.StartTime >= trackView.EndTime)
            {
                ModelState.AddModelError(string.Empty, "End time cannot be equal or less then start time");
            }
            if (trackView.File == null || trackView.File.Length <= 0)
            {
                ModelState.AddModelError("", "Please upload the file");
            }
            if (!_validExtensions.Contains(System.IO.Path.GetExtension(trackView.File.FileName).ToLower()))
            {
                ModelState.AddModelError("", "Please upload the valid file");
            }
            if (ModelState.IsValid)
            {
                var track = _mapper.Map<Track>(trackView);
                await _tracksServices.AddTrack(track);

                //var trackUpdate = _mapper.Map<Track>(trackView);
                //await _tracksServices.UpdateTrack(track.Id, track);

                await _SPfileServices.SaveFile(trackView.File, track.Id);
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
