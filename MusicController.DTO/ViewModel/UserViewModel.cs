using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.ViewModel
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Id { get; set; }
        [Display(Name = "Status")]
        [Required]
        public bool IsAuthorized { get; set; }
    }
}
