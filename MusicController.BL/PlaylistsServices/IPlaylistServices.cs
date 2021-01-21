using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.BL.PlaylistsServices
{
    public interface IPlaylistServices
    {
        Task<List<Playlist>> GetAllPlaylistswithTrackByOutlet(long id);
        Task<Playlist> GetPlaylistswithTrack(long playlistId);
        Task AddPlaylist(Playlist playlist);
        Task UpdatePlaylist(long id, Playlist playlist);
        Task<Playlist> GetPlaylist(long id);
        Task DeletePlaylist(long id);
        Task<List<WeeklyScheduleList>> WeeklyScheduleList(long outletId);
    }
}
