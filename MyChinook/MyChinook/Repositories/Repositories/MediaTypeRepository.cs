using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        private readonly MyChinookContext _db;
        public MediaTypeRepository(MyChinookContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<MediaType> UpdateAsync(MediaType mediaType)
        {
            _db.MediaTypes.Update(mediaType);
            await _db.SaveChangesAsync();
            return mediaType;
        }
    }
}
