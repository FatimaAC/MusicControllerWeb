using System;

namespace MusicController.Entites.Models
{
    public class Track : BaseId
    {
        public long PlaylistId { get; set; }
        public string TrackURL { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Playlist Playlist { get; set; }
    }
}
