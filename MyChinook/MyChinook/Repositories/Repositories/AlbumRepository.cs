using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly MyChinookContext _db;
        public AlbumRepository(MyChinookContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<Album>> GetAlbumByArtistAsync(int id)     
        => await _db.Albums.Where(a => a.ArtistId == id).ToListAsync();

     

        public async Task<Album> UpdateAsync(Album album)
        {
            _db.Albums.Update(album);
            await _db.SaveChangesAsync();
            return album;
        }


    }
}
