using System;

namespace MusicController.Entites.Models
{
    public class Device : BaseId
    {
        public long OutletId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceDetail { get; set; }
        public string StatusMessage { get; set; }
        public string StatusPostedAt { get; set; }
        public DateTime? RequestedAt { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedAt { get; set; }
        public Outlet Outlet { get; set; }
    }
}
