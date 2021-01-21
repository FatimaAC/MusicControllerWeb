using MusicController.Common.Enumerration;
using MusicController.Common.HelperClasses;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using MusicController.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicController.BL.PlaylistsServices
{
    public class PlaylistServices : IPlaylistServices
    {
        private readonly IUnitofWork _unitofWork;

        public PlaylistServices(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task AddPlaylist(Playlist playlist)
        {
            await _unitofWork.PlaylistRepository.AddAsync(playlist);
            _unitofWork.Complete();
        }

        public async Task DeletePlaylist(long id)
        {
            var playlist = await GetPlaylistswithTrack(id);
            _unitofWork.PlaylistRepository.Remove(playlist);
            _unitofWork.Complete();
        }

        public async Task<Playlist> GetPlaylistswithTrack(long playlistId)
        {
            var playlist = await _unitofWork.PlaylistRepository.GetPlaylistswithTrack(playlistId);
            return playlist;
        }
        public async Task<List<Playlist>> GetAllPlaylistswithTrackByOutlet(long id)
        {
            var playlistbyOutlet = await _unitofWork.PlaylistRepository.GetAllPlaylistswithTrackByOutlet(id);
            return playlistbyOutlet.ToList();
        }

        public async Task<Playlist> GetPlaylist(long id)
        {
            var playlist = await _unitofWork.PlaylistRepository.GetAsync(id);
            return playlist;
        }

        public async Task UpdatePlaylist(long id, Playlist playlist)
        {
            var Editplaylist = await GetPlaylist(id);
            if (Editplaylist == null)
            {
                throw new Exception("Record Not found");
            }
            Editplaylist.Name = playlist.Name;
            Editplaylist.OutletId = playlist.OutletId;
            Editplaylist.Schedule = playlist.Schedule;
            Editplaylist.Frequency = playlist.Frequency;
            _unitofWork.PlaylistRepository.UpdateEntity(Editplaylist);
            _unitofWork.Complete();
        }

        public async Task<List<WeeklyScheduleList>> WeeklyScheduleList(long outletId)
        {
            var playlists = await _unitofWork.PlaylistRepository.FindAllAsync(e => e.OutletId == outletId);
            List<WeeklyScheduleList> weeklyScheduleLists = new List<WeeklyScheduleList>();
            if (playlists.Any())
            {
                for (int i = 0; i < 6; i++)
                {
                    var datetime = DateTime.Now.AddDays(i);
                    var dayandMonth = datetime.Day + "/" + datetime.Month.ToString("d2");
                    var dayName = datetime.DayOfWeek.ToString();
                    if (playlists.Any(e => e.Schedule == Schedule.Yearly.ToString() && e.Frequency == dayandMonth))
                    {
                        var yearlyPlaylist = playlists.Where(e => e.Schedule == Schedule.Yearly.ToString() && e.Frequency == dayandMonth).FirstOrDefault();
                        var weeklyDate = PapolateData(yearlyPlaylist, datetime);
                        weeklyScheduleLists.Add(weeklyDate);
                    }
                    else if (playlists.Any(e => e.Schedule == Schedule.Weekly.ToString() && e.Frequency == dayName))
                    {
                        var WeeklyPlaylist = playlists.Where(e => e.Schedule == Schedule.Weekly.ToString() && e.Frequency == dayName).FirstOrDefault();
                        var weeklyDate = PapolateData(WeeklyPlaylist, datetime);
                        weeklyScheduleLists.Add(weeklyDate);
                    }
                    else if (playlists.Any(e => e.Schedule == Schedule.AlternativeDay.ToString()))
                    {
                        int totalDays =DateTimeHelper.TotalNoofDays(datetime);
                        var AlternativeDayPlaylist = playlists.Where(e => e.Schedule == Schedule.AlternativeDay.ToString()).FirstOrDefault();
                        if (totalDays % 2 == 0 && AlternativeDayPlaylist.Frequency == "Even Days")
                        {
                            var AlternativeDayDate = PapolateData(AlternativeDayPlaylist, datetime);
                            weeklyScheduleLists.Add(AlternativeDayDate);
                        }
                        else if (totalDays % 2 != 0 && AlternativeDayPlaylist.Frequency == "Odd Days")
                        {
                            var AlternativeDayDate = PapolateData(AlternativeDayPlaylist, datetime);
                            weeklyScheduleLists.Add(AlternativeDayDate);
                        }
                        else if (playlists.Any(e => e.Schedule == Schedule.Daily.ToString()))
                        {
                            var DailyPlaylist = playlists.Where(e => e.Schedule == Schedule.Daily.ToString()).FirstOrDefault();
                            var DailyDate = PapolateData(DailyPlaylist, datetime);
                            weeklyScheduleLists.Add(DailyDate);
                        }
                    }
                    else if (playlists.Any(e => e.Schedule == Schedule.Daily.ToString()))
                    {
                        var DailyPlaylist = playlists.Where(e => e.Schedule == Schedule.Daily.ToString()).FirstOrDefault();
                        var DailyDate = PapolateData(DailyPlaylist, datetime);
                        weeklyScheduleLists.Add(DailyDate);
                    }
                }
            }
            return weeklyScheduleLists.ToList();
        }

        private WeeklyScheduleList PapolateData( Playlist playlist ,DateTime date)
        {
            var WeeklyScheduleList = new WeeklyScheduleList()
            {
                Date = date.Date,
                Schedule = Regex.Replace(playlist.Schedule, "([a-z])([A-Z])", "$1 $2"),
                Name = playlist.Name
            };
            return WeeklyScheduleList;
        }

    }
}
