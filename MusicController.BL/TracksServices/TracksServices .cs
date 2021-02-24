using MusicController.Entites.Models;
using MusicController.Repository.UnitofWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicController.BL.TrackServices
{
    public class TracksServices : ITracksServices
    {
        private readonly IUnitofWork _unitofWork;
        public TracksServices(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<List<Track>> GetTracksByPlaylist(long playlistId)
        {
            var track = await _unitofWork.TrackRepository.FindAllAsync(e => e.PlaylistId == playlistId);
            return track.ToList();
        }
        public async Task<List<Track>> GetTracksByOutletId(long outletId)
        {
            var playlistId = await _unitofWork.PlaylistRepository.FindAllAsync(e => e.OutletId == outletId);
            var listOfPlaylistIds = playlistId.Select(e => e.Id).ToList();
            var tracks = await _unitofWork.TrackRepository.FindAllAsync(e => listOfPlaylistIds.Contains(e.PlaylistId));
            return tracks.ToList();
        }

        public async Task<List<Track>> GetAllTrack()
        {
            var track = await _unitofWork.TrackRepository.GetAllAsync();

            List<Track> noDups = track.GroupBy(d => new { d.TrackURL })
                              .Select(d => d.First())
                              .ToList();
            return noDups;
            //return track.Distinct().ToList();
        }

        public async Task AddTrack(Track track)
        {
            await _unitofWork.TrackRepository.AddAsync(track);
            _unitofWork.Complete();
        }

        public async Task UpdateTrack(long id, Track track)
        {
            var trackEdit = await GetTrack(id);

            trackEdit.EndTime = track.EndTime;
            trackEdit.StartTime = track.StartTime;
            trackEdit.TrackURL = track.TrackURL;
            _unitofWork.TrackRepository.UpdateEntity(trackEdit);
            _unitofWork.Complete();
        }

        public async Task<Track> GetTrack(long id)
        {
            var track = await _unitofWork.TrackRepository.GetAsync(id);
            return track;
        }

        public async Task DeleteTrack(long id)
        {
            var track = await GetTrack(id);
            _unitofWork.TrackRepository.Remove(track);
            _unitofWork.Complete();
        }
    }
}
