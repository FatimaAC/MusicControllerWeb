using MusicController.Common.EntityHelper;
using System;

namespace MusicController.Identity.Models
{
    public class RefreshToken : BaseId
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public long OutletId { get; set; }
        public string DeviceId { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
