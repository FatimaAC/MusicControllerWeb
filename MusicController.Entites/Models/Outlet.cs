using MusicController.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Entites.Models
{
    public class Outlet : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Device> Devices { get; set; }
        public List<Playlist> Playlist { get; set; }
    }
}
