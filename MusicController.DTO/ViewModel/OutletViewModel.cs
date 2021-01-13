using Microsoft.AspNetCore.Http;
using MusicController.Common.EntityHelper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.ViewModel
{
    public class OutletCreateViewModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Name :")]
        public string Name { get; set; }
        [Display(Name = "Description :")]
        public string Description { get; set; }
        [Display(Name = "Logo :")]
        public string ImageUrl { get; set; }
        [Display(Name = "Logo :")]
        public IFormFile File { get; set; }
    }

    public class OutletViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; }
        [Display(Name = "Total Palylist")]
        public int TotalPlaylists { get; set; }
        [Display(Name = "Total Devices")]
        public int TotalDevices { get; set; }
    }

    public class OutletManageViewModel
    {
        public OutletManageViewModel()
        {
            Outlet = new OutletCreateViewModel();
            OutletPasswords = new OutletPasswordsViewModel();
            Devices = new List<DeviceViewModel>();
        }
        public OutletCreateViewModel Outlet { get; set; }
        public OutletPasswordsViewModel OutletPasswords { get; set; }
        public List<DeviceViewModel> Devices { get; set; }
    }
    public class OutletPasswordsViewModel : BaseId
    {
        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password :")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
