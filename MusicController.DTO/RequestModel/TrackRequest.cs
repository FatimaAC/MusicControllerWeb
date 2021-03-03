using MusicController.Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicController.DTO.RequestModel
{
    public class TrackRequest
    {
        public string Token { get; set; }
        public string SecretString { get; set; }
    }
}
