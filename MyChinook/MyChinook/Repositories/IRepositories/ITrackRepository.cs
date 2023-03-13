using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        Task<Track> UpdateAsync(Track track);
    }
}
