using MusicController.Common.EntityHelper;
using System.Collections.Generic;

namespace MusicController.Entites.Models
{
    public class Playlist : AuditableEntity
    {
        public long OutletId { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }
        public string Frequency { get; set; }
        public Outlet Outlet { get; set; }
        public List<Track> Tracks { get; set; }

    }
}
