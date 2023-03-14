using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IPlaylistTrackRepository : IRepository<PlaylistTrack>
    {
        Task<PlaylistTrack> UpdateAsync(PlaylistTrack playlistTrack);        
    }
}
