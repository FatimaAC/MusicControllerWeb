using Microsoft.AspNetCore.Identity;

namespace MusicController.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAuthorized { get; set; } = false;
        public string ApprovedBy { get; set; }
        public ApplicationUser ApprovedByUser { get; set; }
    }
}
