using MusicController.Common.EntityHelper;
using System.Collections.Generic;

namespace MusicController.Entites.Models
{
    public class Outlet : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public List<Device> Devices { get; set; }
        public List<Playlist> Playlist { get; set; }
    }
}
