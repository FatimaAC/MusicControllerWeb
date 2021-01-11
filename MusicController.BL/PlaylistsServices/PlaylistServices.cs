using MusicController.Entites.Models;
using MusicController.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var playlist = await GetPlaylist(id);
            _unitofWork.PlaylistRepository.Remove(playlist);
            _unitofWork.Complete();
        }

       public async Task<Playlist> GetAllPlaylistswithTrack(long playlistId)
        {
            var playlist = await _unitofWork.PlaylistRepository.GetAllPlaylistswithTrack(playlistId);
            return playlist;
        }
        public async Task<List<Playlist>> GetAllPlaylists()
        {
            throw new NotImplementedException();
        }
        public async Task<List<Playlist>> GetAllPlaylistswithTrackByOutlet(long id)
        {
            var playlistbyOutlet = await _unitofWork.PlaylistRepository.GetAllPlaylistswithTrackByOutlet(id);
            return playlistbyOutlet.ToList();
        }

        public async Task<Playlist> GetPlaylist(long id)
        {
            var playlist =await _unitofWork.PlaylistRepository.GetAsync(id);
            return playlist;
        }

        public async Task UpdatePlaylist(long id, Playlist playlist)
        {
            var Editplaylist = await GetPlaylist(id);
            if (Editplaylist==null)
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
    }
}
