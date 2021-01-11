using MusicController.Entites.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.BL.TrackServices
{
    public interface ITracksServices
    {
        Task<List<Device>> GetAllTracks();
        Task AddTrack(Track track);
        Task UpdateTrack(long id, Track track);
        Task<Track> GetTrack(long id);
        Task DeleteTrack(long id);
        Task ApproveTrack(long id);
    }
}
