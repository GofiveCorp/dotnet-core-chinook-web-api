using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        private readonly ApplicationDbContext _db; 
        public PlaylistRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
            _db = dbContext;  
        }

        public async Task<Playlist>UpdateAsync(Playlist playlist)
        {
            _db.Update(playlist);
            await _db.SaveChangesAsync();
            return playlist;
        }       
    }
}
