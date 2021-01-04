using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Entites.Models
{
    public class Playlist : AuditableEntity
    {
        public long OutletId { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }
        public byte Frequency { get; set; }
        public  Outlet Outlet { get; set; }
        public  Track Track { get; set; }

    }
}
