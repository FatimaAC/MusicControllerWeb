using MusicController.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.RequestModel
{
    public class LoginRequest
    {
        [Required]
        public long OutletId { get; set; }
        [Required]
        [StringLength(DeviceConstant.MaxDeviceIdLength, ErrorMessage = "The {0} must be {2} character long.", MinimumLength = DeviceConstant.MaxDeviceIdLength)]
        public string DeviceId { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
