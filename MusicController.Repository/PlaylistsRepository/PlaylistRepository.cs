using Microsoft.EntityFrameworkCore;
using MusicController.Entites.Context;
using MusicController.Entites.Models;
using MusicController.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.Repository.PlaylistsRepository
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        private readonly MusicDBContext _musicDbContext;

        public PlaylistRepository(MusicDBContext musicDbContext) : base(musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        public async Task<IEnumerable<Playlist>> GetAllPlaylistswithTrackByOutlet(long id)
        {
            var playlists = await _musicDbContext.Playlists
                            .Include(e => e.Tracks)
                            .Where(e => e.OutletId == id)
                            .ToListAsync();
            // order track by start time
            foreach (var item in playlists)
            {
                item.Tracks = item.Tracks.OrderBy(e => e.StartTime).ToList();
            }
            return playlists;
        }

        public async Task<Playlist> GetPlaylistswithTrack(long playlistid)
        {
            var playlists = await _musicDbContext.Playlists
                            .Include(e => e.Tracks)
                            .Where(e => e.Id == playlistid)
                            .FirstOrDefaultAsync();
            return playlists;
        }

    }
}
