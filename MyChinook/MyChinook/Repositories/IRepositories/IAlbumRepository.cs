using MyChinook.Models;
using MyChinook.Models.Dtos;

namespace MyChinook.Repositories.IRepositories
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAllAlbumsAsync(CancellationToken cancellationToken);
        Task<Album> GetAnAlbumAsync(int albumId, CancellationToken cancellationToken);
        Task<List<Album>> GetAlbumsByArtistAsync(int albumId, CancellationToken cancellationToken);
        Task<AlbumDto> CreateAlbumAsync(int artistId, AlbumCreateDto albumCreateDto, CancellationToken cancellationToken);
        Task<AlbumDeleteDto> DeleteAlbumAsync(int albumId, CancellationToken cancellationToken);
        Task<AlbumDetailDto> UpdateAlbumAsync(int albumId, AlbumUpdateDto albumUpdateDto, CancellationToken cancellationToken);
    }
}
