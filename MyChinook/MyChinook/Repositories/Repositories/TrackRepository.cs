using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly MyChinookContext _db;
        public TrackRepository(MyChinookContext dbContext) 
        {
            _db = dbContext;
        }

        public async Task<List<Track>> GetTrackByAlbumAsync(int id)
        => await _db.Tracks.Where(u => u.AlbumId == id).ToListAsync();

        public async Task<List<Track>> GetTrackByGenreAsync(int id)
        => await _db.Tracks.Where(u => u.GenreId == id).ToListAsync();

        public async Task<List<Track>> GetTrackByMediaTypeAsync(int id)
        => await _db.Tracks.Where(u => u.MediaTypeId == id).ToListAsync();

        public async Task<Track> UpdateAsync(Track track)
        {
            _db.Tracks.Update(track);
            await _db.SaveChangesAsync();
            return track;
        }
    }
}
