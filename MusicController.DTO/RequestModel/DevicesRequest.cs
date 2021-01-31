using MusicController.Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.RequestModel
{
    public class DevicesRequest
    {

        [Required(ErrorMessage = "Please select Outlet Id")]
        [Range(1, long.MaxValue, ErrorMessage = "Please select Outlet Id")]
        public long OutletId { get; set; }
        [Required(ErrorMessage = "Please select DeviceId")]
        [StringLength(DeviceConstant.MaxDeviceIdLength, ErrorMessage = "The {0} must be {2} character long.", MinimumLength = DeviceConstant.MaxDeviceIdLength)]
        public string DeviceId { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [StringLength(OutletConstant.MaxNameLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string DeviceDetail { get; set; }
    }
}
