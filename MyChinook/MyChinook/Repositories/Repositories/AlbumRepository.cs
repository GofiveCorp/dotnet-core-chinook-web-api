using Microsoft.EntityFrameworkCore;
using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext _db;
        public AlbumRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<Album>> GetAlbumByArtistAsync(int id)     
        => await _db.Album.Where(a => a.ArtistId == id).ToListAsync();
        
        public async Task<Album> UpdateAsync(Album album)
        {
            _db.Album.Update(album);
            await _db.SaveChangesAsync();
            return album;
        }


    }
}
