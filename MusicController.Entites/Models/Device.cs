using MusicController.Common.EntityHelper;
using System;

namespace MusicController.Entites.Models
{
    public class Device : BaseId
    {
        public long OutletId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceDetail { get; set; }
        public string StatusMessage { get; set; }
        public DateTime? StatusPostedAt { get; set; }
        public DateTime? RequestedAt { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public Outlet Outlet { get; set; }
    }
}
