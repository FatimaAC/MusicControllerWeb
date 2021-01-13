using MusicController.Entites.Models;
using MusicController.Identity.UserService;
using MusicController.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicController.BL.TrackServices
{
    public class TracksServices : ITracksServices
    {
        private readonly IUnitofWork _unitofWork;
        public TracksServices(IUnitofWork unitofWork, ICurrentUserService currentUserService)
        {
            _unitofWork = unitofWork;
        }
        public Task<List<Device>> GetAllTracks()
        {
            throw new NotImplementedException();
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

        public Task ApproveTrack(long id)
        {
            throw new NotImplementedException();
        }
    }
}
