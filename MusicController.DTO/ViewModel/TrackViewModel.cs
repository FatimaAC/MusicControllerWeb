using MusicController.Common.EntityHelper;
using System;
using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.ViewModel
{
    public class TrackViewModel : BaseId
    {
        public long PlaylistId { get; set; }
        [Display(Name = "Track Link:")]
        [Required]
        public string TrackURL { get; set; }
        [Required]
        [Display(Name = "Start time:")]
        public TimeSpan StartTime { get; set; }
        [Required]
        [Display(Name = "End time:")]
        public TimeSpan EndTime { get; set; }
        public PlaylistViewModel Playlist { get; set; }
    }
}
