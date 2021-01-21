using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.DevicesServices;
using MusicController.BL.FileServices;
using MusicController.BL.OutletServices;
using MusicController.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicControllerWeb.Components.EditOutlet
{
    public class AddTrackViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(long playlistId)
        {
            TrackViewModel trackViewModel = new TrackViewModel()
            {
                PlaylistId = playlistId
            };
            return await Task.FromResult((IViewComponentResult)View("AddTrack", trackViewModel));
        }
    }
}
