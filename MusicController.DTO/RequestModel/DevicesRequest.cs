using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicController.DTO.RequestModel
{
    public class DevicesRequest
    {
       
        [Required(ErrorMessage = "Please select Outlet Id")]
        [Range( 1, long.MaxValue, ErrorMessage = "Please select Outlet Id")]
        public long OutletId { get; set; }
        [Required(ErrorMessage = "Please select DeviceId")]
        public string DeviceId { get; set; }
    }
}
