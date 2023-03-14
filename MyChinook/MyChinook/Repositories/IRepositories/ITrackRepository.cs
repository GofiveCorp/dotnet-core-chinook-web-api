using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        Task<Track> UpdateAsync(Track track);

        Task<List<Track>> GetTrackByAlbumAsync(int id);
        Task<List<Track>> GetTrackByGenreAsync(int id);
        Task<List<Track>> GetTrackByMediaTypeAsync(int id);     
    }
}
