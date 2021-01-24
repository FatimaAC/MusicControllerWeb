using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace MusicController.DTO.RequestModel
{
  public  class DeviceStatusRequest
    {
        public string DeviceId { get; set; }
        public string StatusMessage { get; set; }
        [DataType(DataType.Date)]
        public DateTime StatusPostedAt { get; set; }
    }
}
