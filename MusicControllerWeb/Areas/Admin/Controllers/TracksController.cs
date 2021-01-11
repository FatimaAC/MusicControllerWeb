using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.DevicesServices;
using MusicController.BL.TrackServices;
using MusicController.Common.Constants;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicControllerWeb.Areas.Admin.Controllers
{
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.Dj)]
    public class TracksController : Controller
    {

        private readonly ITracksServices _TracksServices;
        private readonly IMapper _mapper;
        public TracksController(ITracksServices tracksServices, IMapper mapper)
        {
            _TracksServices = tracksServices;
            _mapper = mapper;
        }

        public async Task<IActionResult> Edit(long id)
        {
            var track = await _TracksServices.GetTrack(id);
            var tracViewModel = _mapper.Map<TrackViewModel>(track);
            return View(tracViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(long id ,TrackViewModel trackViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var track = _mapper.Map<Track>(trackViewModel);
                    await _TracksServices.UpdateTrack(id, track);
                    return RedirectToAction("Edit", "Playlist", new { id = trackViewModel.PlaylistId, Area = UserRolesConstant.Admin });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                return View(trackViewModel);
            }
           
            return View(trackViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id ,long playlistId)
        {
            await _TracksServices.DeleteTrack(id);
            return RedirectToAction("Edit", "Playlist", new { id = playlistId, Area = UserRolesConstant.Admin });

        }

    }
}
