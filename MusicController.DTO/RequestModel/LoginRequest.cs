using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicController.DTO.RequestModel
{
    public class LoginRequest
    {
        [Required]
        public long OutletId { get; set; }
        [Required]
        public string DeviceId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
