using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.DTO.ViewModel
{
   public class DeviceViewModel : BaseIdViewModel
    {
         public long OutletId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceDetail { get; set; }
        public string Password { get; set; }
        public string StatusMessage { get; set; }
        public string StatusPostedAt { get; set; }
        public DateTime? RequestedAt { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedAt { get; set; }
        public virtual OutletCreateViewModel Outlet { get; set; }
    }
}
