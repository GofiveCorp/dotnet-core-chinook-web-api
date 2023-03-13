using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> UpdateAsync(Artist artist);
    }
}
