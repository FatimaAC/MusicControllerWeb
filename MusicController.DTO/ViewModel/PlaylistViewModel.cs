using MusicController.Common.EntityHelper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.ViewModel
{
    public class PlaylistIndexModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long OutletId { get; set; }
        [Required]
        [Display(Name = "Playlist Name:")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Schedule")]
        public string Schedule { get; set; }
        public string Frequency { get; set; }
        public OutletCreateViewModel Outlet { get; set; }
        public List<TrackViewModel> Tracks { get; set; }
    }


    public class PlaylistwithTrackViewModel : BaseId
    {
        public PlaylistwithTrackViewModel()
        {
            Playlist = new PlaylistIndexModel();
            AddTrack = new TrackViewModel();
        }
        public PlaylistIndexModel Playlist { get; set; }
        public PlaylistIndexModel EditPlaylist { get; set; }
        public TrackViewModel AddTrack { get; set; }
    }
}
