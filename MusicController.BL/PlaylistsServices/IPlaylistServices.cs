using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicController.BL.PlaylistsServices
{
    public interface IPlaylistServices
    {
        Task<List<Playlist>> GetAllPlaylists();
        Task<List<Playlist>> GetAllPlaylistswithTrackByOutlet(long id);
        Task<Playlist> GetAllPlaylistswithTrack(long playlistId);
        Task AddPlaylist(Playlist playlist);
        Task UpdatePlaylist(long id, Playlist playlist);
        Task<Playlist> GetPlaylist(long id);
        Task DeletePlaylist(long id);
    }
}
