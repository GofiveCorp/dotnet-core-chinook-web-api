using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class PlaylistTrackRepository : Repository<PlaylistTrack>, IPlaylistTrackRepository
    {
        private readonly ApplicationDbContext _db;
        public PlaylistTrackRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<PlaylistTrack> UpdateAsync(PlaylistTrack playlistTrack)
        {
            _db.Update(playlistTrack);
            await _db.SaveChangesAsync();
            return playlistTrack;
        }
    }
}
