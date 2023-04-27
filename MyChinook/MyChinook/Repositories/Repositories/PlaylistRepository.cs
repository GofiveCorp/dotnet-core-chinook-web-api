using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        private readonly MyChinookContext _db; 
        public PlaylistRepository(MyChinookContext dbContext) :base(dbContext)
        {
            _db = dbContext;  
        }

        public async Task<Playlist>UpdateAsync(Playlist playlist)
        {
            _db.Playlists.Update(playlist);
            await _db.SaveChangesAsync();
            return playlist;
        }       
    }
}
