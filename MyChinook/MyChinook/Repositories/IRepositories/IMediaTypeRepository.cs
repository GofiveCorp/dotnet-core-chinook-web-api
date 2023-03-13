using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IMediaTypeRepository : IRepository<MediaType>
    {
        Task<MediaType> UpdateAsync(MediaType mediaType);
    }
}
