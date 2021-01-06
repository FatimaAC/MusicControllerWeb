using System;
using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.ViewModel
{
    public class DeviceViewModel : BaseIdViewModel
    {
        public long OutletId { get; set; }
        [Display(Name = "Device Id")]
        public string DeviceId { get; set; }
        [Display(Name = "Device Detail")]
        public string DeviceDetail { get; set; }
        [Display(Name = "Status Message")]
        public string StatusMessage { get; set; }
        public string StatusPostedAt { get; set; }
        public DateTime? RequestedAt { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedAt { get; set; }
        public virtual OutletCreateViewModel Outlet { get; set; }
    }

    public class DeviceDeleteViewModel : BaseIdViewModel
    {
        public long OutletId { get; set; }
    }
}
