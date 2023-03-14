using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class MediaTypeRepository : Repository<MediaType>, IMediaTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public MediaTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<MediaType> UpdateAsync(MediaType mediaType)
        {
            _db.MediaType.Update(mediaType);
            await _db.SaveChangesAsync();
            return mediaType;
        }
    }
}
