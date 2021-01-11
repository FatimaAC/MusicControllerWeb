using MusicController.Common.EntityHelper;
using System;

namespace MusicController.Entites.Models
{
    public class Track : BaseId
    {
        public long PlaylistId { get; set; }
        public string TrackURL { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Playlist Playlist { get; set; }
    }
}
