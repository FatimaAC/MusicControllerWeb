using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicController.Identity.Model
{
    public  class ApplicationUser : IdentityUser
    {
        public bool IsAuthorized { get; set; } = false;
        public string ApprovedBy { get; set; }
        public ApplicationUser ApprovedByUser { get; set; }
    }
}
