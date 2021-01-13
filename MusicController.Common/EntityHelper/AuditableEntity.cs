using System;
using System.ComponentModel.DataAnnotations;

namespace MusicController.Common.EntityHelper
{
    public abstract class AuditableEntity : BaseId
    {
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

}
