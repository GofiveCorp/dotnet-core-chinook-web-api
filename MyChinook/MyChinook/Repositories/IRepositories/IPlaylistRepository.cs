using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<Playlist> UpdateAsync(Playlist playlist);
    }
}
