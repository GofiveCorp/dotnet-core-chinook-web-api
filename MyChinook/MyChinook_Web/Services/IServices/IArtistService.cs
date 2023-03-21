using MyChinook_Web.Models.Dtos;

namespace MyChinook_Web.Services.IServices
{
    public interface IArtistService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(ArtistDto artistDto);
        Task<T> UpdateAsync<T>(ArtistDto artistDto);
        Task<T> DeleteAsync<T>(int id);
    }
}
