using MyChinook.Models;

namespace MyChinook.Repositories.IRepositories
{
    public interface IPlaylistRepository 
    {
        Task<List<Playlist>> GetAllPlaylistsAsync(CancellationToken cancellationToken);
    }
}
