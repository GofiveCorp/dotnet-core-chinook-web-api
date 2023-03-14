using Microsoft.EntityFrameworkCore;
using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        private readonly ApplicationDbContext _db;
        public TrackRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<Track>> GetTrackByAlbumAsync(int id)
        => await _db.Track.Where(u => u.AlbumId == id).ToListAsync();

        public async Task<List<Track>> GetTrackByGenreAsync(int id)
        => await _db.Track.Where(u => u.GenreId == id).ToListAsync();

        public async Task<List<Track>> GetTrackByMediaTypeAsync(int id)
        => await _db.Track.Where(u => u.MediaTypeId == id).ToListAsync();

        public async Task<Track> UpdateAsync(Track track)
        {
            _db.Track.Update(track);
            await _db.SaveChangesAsync();
            return track;
        }

    }
}
