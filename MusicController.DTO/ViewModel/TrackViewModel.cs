using MusicController.Common.EntityHelper;
using MusicController.Common.HelperClasses;
using MusicControllerWeb.Areas.Admin.Models;
using MusicControllerWeb.Areas.Admin.Models.DateComparisons.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicController.DTO.ViewModel
{
    public class TrackViewModel : BaseId    
    {
        [Required]
        public long PlaylistId { get; set; }
        [Display(Name = "Track Link:")]
        [Required]
        public string TrackURL { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required]
        [Display(Name = "Start time:")]
        public string FormatedStartTime { get; set; }
        [Required]
        [Display(Name = "End time:")]
        public string FormatedEndTime { get; set; }
       
       
    }

    public class WeeklyScheduleList
    {
        public long PlaylistId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Schedule { get; set; }
        public string Name { get; set; }
        public List<TrackViewModel> Tracks { get; set; }

    }
}
