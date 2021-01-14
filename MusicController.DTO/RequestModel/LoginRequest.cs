using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.DTO.RequestModel
{
    public class LoginRequest
    {
        public long OutletId { get; set; }
        public string DeviceId { get; set; }
        public string Password { get; set; }
    }
}
