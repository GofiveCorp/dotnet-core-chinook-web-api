using MyChinook.Models;

namespace MyChinook.Repositories.IRepositories
{
    public interface IPlaylistRepository 
    {
        Task<Playlist> UpdateAsync(Playlist playlist);
    }
}
