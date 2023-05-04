using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenresAsync(CancellationToken cancellationToken);
    }         
}
