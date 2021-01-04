using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.DTO.ViewModel
{
   public class TrackViewModel : BaseIdViewModel
    {
        public long PlaylistId { get; set; }
        public string TrackURL { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual PlaylistViewModel Playlist { get; set; }
    }
}
