using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface IGenreRepository
    {
        Task<Genre> UpdateAsync(Genre genre);
    }         
}
