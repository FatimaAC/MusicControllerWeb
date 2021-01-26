using MusicController.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.DTO.DTOModel
{
    public class WeeklyScheduleListDTO
    {
        public List<WeeklyScheduleList> WeeklyScheduleLists { get; set; }
        public List<TrackViewModel> Tracks { get; set; }
    }
}
