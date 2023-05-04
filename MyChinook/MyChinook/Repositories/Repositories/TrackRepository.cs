using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly MyChinookContext db;
        public TrackRepository(MyChinookContext dbContext) 
        {
            db = dbContext;
        }

        public async Task<List<Track>> GetAllTracksAsync(CancellationToken cancellationToken)
        {
            var track = await db.Tracks.ToListAsync(cancellationToken);
            return track;
        }

        public async Task<List<Track>> GetTrackByAlbumAsync(int id)
        => await db.Tracks.Where(u => u.AlbumId == id).ToListAsync();

        public async Task<List<Track>> GetTrackByGenreAsync(int id)
        => await db.Tracks.Where(u => u.GenreId == id).ToListAsync();

        public async Task<List<Track>> GetTrackByMediaTypeAsync(int id)
        => await db.Tracks.Where(u => u.MediaTypeId == id).ToListAsync();

        public async Task<Track> UpdateAsync(Track track)
        {
            db.Tracks.Update(track);
            await db.SaveChangesAsync();
            return track;
        }
    }
}
