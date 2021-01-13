using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.PlaylistsServices;
using MusicController.BL.TrackServices;
using MusicController.Common.Constants;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicControllerWeb.Areas.Admin.Controllers
{
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.Admin)]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistServices _playlistServices;
        private readonly ITracksServices _tracksServices;
        private readonly IMapper _mapper;
        public PlaylistController(IPlaylistServices playlistServices, IMapper mapper, ITracksServices tracksServices)
        {
            _playlistServices = playlistServices;
            _mapper = mapper;
            _tracksServices = tracksServices;
        }
        // GET: PlaylistController
        public async Task<ActionResult> Index(long id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            ViewBag.OutletId = id;
            var playlists = await _playlistServices.GetAllPlaylistswithTrackByOutlet(id);
            PlaylistViewModel playlistViewModel = new PlaylistViewModel
            {
                Playlists = _mapper.Map<List<PlaylistIndexModel>>(playlists)
            };
            return View(playlistViewModel);
        }

        // GET: PlaylistController/Create
        public ActionResult Create(long id)
        {
            PlaylistIndexModel playlist = new PlaylistIndexModel()
            {
                OutletId = id
            };
            return View(playlist);
        }

        // POST: PlaylistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlaylistIndexModel playlist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var outlet = _mapper.Map<Playlist>(playlist);
                    await _playlistServices.AddPlaylist(outlet);
                    return RedirectToAction("Index", "Playlist", new { id = playlist.OutletId, Area = UserRolesConstant.Admin });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                return View(playlist);
            }
            return View(playlist);
        }

        // GET: PlaylistController/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            var playlist = await _playlistServices.GetPlaylistswithTrack(id);
            if (playlist == null)
            {
                return NotFound();
            }
            PlaylistwithTrackViewModel playlistwithTrackViewModel = new PlaylistwithTrackViewModel()
            {
                Playlist = _mapper.Map<PlaylistIndexModel>(playlist)
            };
            return View(playlistwithTrackViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long id, PlaylistIndexModel Playlist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var playlist = _mapper.Map<Playlist>(Playlist);
                    await _playlistServices.UpdatePlaylist(id, playlist);
                    return RedirectToAction("Edit", "Playlist", new { id, Area = UserRolesConstant.Admin });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                return View(Playlist);
            }
            return View(Playlist);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrack(long id, TrackViewModel trackView)
        {
            try
            {
                trackView.Id = 0;
                if (ModelState.IsValid)
                {
                    var track = _mapper.Map<Track>(trackView);
                    await _tracksServices.AddTrack(track);
                    return RedirectToAction("Edit", "Playlist", new { id = id, Area = UserRolesConstant.Admin });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                return View($"/Admin/Playlist/Edit/{id}", trackView);
            }
            return View($"/Admin/Playlist/Edit/{id}", trackView);
        }

        // GET: PlaylistController/Delete/5
        public ActionResult AddTrack(long id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, long OutletId)
        {
            await _playlistServices.DeletePlaylist(id);
            return RedirectToAction("Index", "Playlist", new { id = OutletId, Area = UserRolesConstant.Admin });

        }

    }
}
