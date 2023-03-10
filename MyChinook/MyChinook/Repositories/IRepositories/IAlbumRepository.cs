using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<Album> UpdateAsync(Album album);

        Task<List<Album>> GetAlbumByArtistAsync(int id);
    }
}
