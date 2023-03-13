using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<Genre> UpdateAsync(Genre genre);
    }
}
