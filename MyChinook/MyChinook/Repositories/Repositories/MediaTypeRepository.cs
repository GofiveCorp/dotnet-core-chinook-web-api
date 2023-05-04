using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        private readonly MyChinookContext db;
        public MediaTypeRepository(MyChinookContext dbContext)
        {
            db = dbContext;
        }

        public async Task<List<MediaType>> GetAllMediaTypesAsync(CancellationToken cancellationToken)
        {
            var mediaType = await db.MediaTypes.ToListAsync(cancellationToken);
            return mediaType;
        }    
    }
}
