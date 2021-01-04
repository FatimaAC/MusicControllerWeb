using Microsoft.AspNetCore.Http;
using MusicController.Identity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicController.DTO.ViewModel
{
    public class OutletCreateViewModel 
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public IFormFile File { get; set; } 
    }

    public class OutletViewModel 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public int TotalPalylist { get; set; }
        public int TotalDevices { get; set; }
        public int MyProperty { get; set; }
    }
}
