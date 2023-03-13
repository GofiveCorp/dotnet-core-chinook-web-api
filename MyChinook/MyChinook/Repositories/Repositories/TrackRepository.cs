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

        public async Task<Track> UpdateAsync(Track track)
        {
            _db.Track.Update(track);
            await _db.SaveChangesAsync();
            return track;
        }
    }
}
