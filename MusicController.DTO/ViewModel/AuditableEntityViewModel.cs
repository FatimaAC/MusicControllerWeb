using System;

namespace MusicController.DTO.ViewModel
{
    public class AuditableEntityViewModel : BaseIdViewModel
    {
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
