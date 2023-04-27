using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class ArtistRepository : Repository<Artist>,IArtistRepository
    {
        private readonly MyChinookContext _db;
        public ArtistRepository(MyChinookContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<Artist> UpdateAsync(Artist artist)
        {
            _db.Artists.Update(artist);
            await _db.SaveChangesAsync();
            return artist;
        }
    }
}
