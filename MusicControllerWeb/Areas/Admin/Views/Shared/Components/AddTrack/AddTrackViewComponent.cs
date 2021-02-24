using Microsoft.AspNetCore.Mvc;
using MusicController.DTO.ViewModel;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicController.BL.TrackServices;

namespace MusicControllerWeb.Components.EditOutlet
{
    public class AddTrackViewComponent : ViewComponent
    {
        private readonly ITracksServices _tracksServices;
        public AddTrackViewComponent(ITracksServices tracksServices)
        {
            _tracksServices = tracksServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(long playlistId)
        {
            TrackViewModel trackViewModel = new TrackViewModel()
            {
                PlaylistId = playlistId
            };
            var getAllTracks = await _tracksServices.GetAllTrack();
            //ViewBag.Tracks = new SelectList(getAllTracks, "Id", "TrackURL");

            ViewBag.Tracks = getAllTracks.Select(e => new SelectListItem { Value = e.TrackURL.Substring(e.TrackURL.LastIndexOf('/') + 1), Text = e.TrackURL.Substring(e.TrackURL.LastIndexOf('/') + 1) }).ToList();

            return await Task.FromResult((IViewComponentResult)View("AddTrack", trackViewModel));
        }
    }
}
