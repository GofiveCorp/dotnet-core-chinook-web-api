using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly MyChinookContext _db;
        public GenreRepository(MyChinookContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<Genre> UpdateAsync(Genre genre)
        {
            _db.Genres.Update(genre);
            await _db.SaveChangesAsync();   
            return genre;
        }
    }
}
