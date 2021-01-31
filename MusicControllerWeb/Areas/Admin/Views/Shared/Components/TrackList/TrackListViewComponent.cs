using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.TrackServices;
using MusicController.DTO.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicControllerWeb.Components.EditOutlet
{
    public class TrackListViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ITracksServices _tracksServices;
        public TrackListViewComponent(IMapper mapper, ITracksServices tracksServices)
        {
            _tracksServices = tracksServices;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(long playlistId)
        {
            var tracks = await _tracksServices.GetTracksByPlaylist(playlistId);
            var trackViewModel = _mapper.Map<List<TrackViewModel>>(tracks);
            return View("TrackList", trackViewModel);
        }
    }
}
