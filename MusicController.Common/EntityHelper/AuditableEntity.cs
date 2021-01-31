using MusicController.Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace MusicController.Common.EntityHelper
{
    // Common Prorperty for the ef Model and ViewModel or Dto ,Request Model
    public abstract class AuditableEntity : BaseId
    {
        [MaxLength(AuditableEntityConstant.MaxApplicationUserIdLength)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        [MaxLength(AuditableEntityConstant.MaxApplicationUserIdLength)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
