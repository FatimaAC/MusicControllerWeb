﻿using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.ViewModel
{
    public class UserViewModel
    {
        public string Email { get; set; }
        [Required]
        public string Id { get; set; }
        [Display(Name = "Approved")]
        [Required]
        public bool IsAuthorized { get; set; }
        [Display(Name = "User Role")]
        [Required]
        public string Role { get; set; }
    }
}
