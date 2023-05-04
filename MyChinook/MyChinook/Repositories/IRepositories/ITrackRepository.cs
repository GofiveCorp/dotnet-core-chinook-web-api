using MyChinook.Models;

namespace MyChinook.Repositories.IRepositories
{
    public interface ITrackRepository 
    {
        Task<List<Track>> GetAllTracksAsync(CancellationToken cancellationToken); 
        Task<List<Track>> GetTrackByAlbumAsync(int id);
        Task<List<Track>> GetTrackByGenreAsync(int id);
        Task<List<Track>> GetTrackByMediaTypeAsync(int id);     
    }
}
