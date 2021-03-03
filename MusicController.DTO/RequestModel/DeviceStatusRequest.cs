using MusicController.Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicController.DTO.RequestModel
{
    public class DeviceStatusRequest
    {
        [JsonIgnore]
        public string DeviceId { get; set; }
        [Required]
        [StringLength(DeviceConstant.MaxStatusMessageLength, ErrorMessage = "The {0} must be {2} character long.", MinimumLength = 1)]
        public string StatusMessage { get; set; }
        [Required]
        public DateTime StatusPostedAt { get; set; }
        public string Token { get; set; }
        public string SecretString { get; set; }
    }
}
