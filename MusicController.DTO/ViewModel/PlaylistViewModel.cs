using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.DTO.ViewModel
{
    public class PlaylistViewModel : AuditableEntityViewModel
    {
        public long OutletId { get; set; }
        public int Name { get; set; }
        public string Schedule { get; set; }
        public byte Frequency { get; set; }
        public virtual OutletCreateViewModel Outlet { get; set; }
        public virtual TrackViewModel Track { get; set; }
    }
}
