using MusicController.Entites.Models;
using MusicController.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicController.Repository.PlaylistsRepository
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        Task<IEnumerable<Playlist>> GetAllPlaylistswithTrackByOutlet(long id);
        Task<Playlist> GetAllPlaylistswithTrack(long playlistid);
    }
}
