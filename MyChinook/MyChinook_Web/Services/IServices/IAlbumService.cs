using MyChinook_Web.Models.Dtos;

namespace MyChinook_Web.Services.IServices
{
    public interface IAlbumService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(AlbumDto albumDto);
        Task<T> UpdateAsync<T>(AlbumDto albumDto);
        Task<T> DeleteAsync<T>(int id);
    }
}
