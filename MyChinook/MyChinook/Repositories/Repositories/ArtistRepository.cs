using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class ArtistRepository : Repository<Artist>,IArtistRepository
    {
        private readonly ApplicationDbContext _db;
        public ArtistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<Artist> UpdateAsync(Artist artist)
        {
            _db.Artist.Update(artist);
            await _db.SaveChangesAsync();
            return artist;
        }
    }
}
