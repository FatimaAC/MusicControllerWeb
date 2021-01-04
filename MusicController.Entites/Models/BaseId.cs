using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicController.Entites.Models
{
   public abstract class BaseId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
    }
}
