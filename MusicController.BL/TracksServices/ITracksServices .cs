using MusicController.Entites.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.BL.TrackServices
{
    public interface ITracksServices
    {
        Task<List<Track>> GetTracksByPlaylist(long playlistId);
        Task<List<Track>> GetTracksByOutletId(long outletId);
        Task AddTrack(Track track);
        Task UpdateTrack(long id, Track track);
        Task<Track> GetTrack(long id);
        Task DeleteTrack(long id);
    }
}
