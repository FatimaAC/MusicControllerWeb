using MusicController.DTO.ViewModel;
using System.Collections.Generic;

namespace MusicController.DTO.DTOModel
{
    public class WeeklyScheduleListDTO
    {
        public List<WeeklyScheduleList> WeeklyScheduleLists { get; set; }
        public List<TrackViewModel> Tracks { get; set; }
    }
}
