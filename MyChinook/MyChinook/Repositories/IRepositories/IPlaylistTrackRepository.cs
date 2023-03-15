using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IPlaylistTrackRepository : IRepository<PlaylistTrack>
    {
        Task<PlaylistTrack> UpdateAsync(PlaylistTrack playlistTrack);

        Task<List<PlaylistTrack>> GetPlaylistTrackByPlaylistAsync(int id);
        Task<List<PlaylistTrack>> GetPlaylistTrackByTrackAsync(int id);
    }
}
