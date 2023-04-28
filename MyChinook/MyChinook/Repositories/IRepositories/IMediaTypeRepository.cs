using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface IMediaTypeRepository 
    {
        Task<MediaType> UpdateAsync(MediaType mediaType);
    }
}
