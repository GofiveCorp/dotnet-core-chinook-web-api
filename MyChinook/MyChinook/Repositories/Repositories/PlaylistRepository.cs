using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly MyChinookContext db; 
        public PlaylistRepository(MyChinookContext dbContext) 
        {
            db = dbContext;  
        }

        public async Task<List<Playlist>> GetAllPlaylistsAsync(CancellationToken cancellationToken)
        {
            var playlist = await db.Playlists.ToListAsync(cancellationToken);
            return playlist;
        }      
    }
}
