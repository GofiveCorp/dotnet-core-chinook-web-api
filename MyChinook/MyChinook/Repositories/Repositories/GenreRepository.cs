using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MyChinookContext db;
        public GenreRepository(MyChinookContext dbContext)
        {
            db = dbContext;
        }

        public async Task<List<Genre>> GetAllGenresAsync(CancellationToken cancellationToken)
        {
            var genre = await db.Genres.ToListAsync(cancellationToken);
            return genre;
        }
    }
}
