using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface IMediaTypeRepository 
    {
        Task<List<MediaType>> GetAllMediaTypesAsync(CancellationToken cancellationToken);
    }
}
