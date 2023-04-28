using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Models.Dtos;
using MyChinook.Repositories.IRepositories;
using System.Threading;

namespace MyChinook.Repositories.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MyChinookContext db;
        private readonly IMapper mapper;

        public ArtistRepository(MyChinookContext dbContext, IMapper mapper) 
        {
            db = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<Artist>> GetAllArtistsAsync(CancellationToken cancellationToken)
        {
            var artists = await db.Artists.ToListAsync(cancellationToken);
            return artists;
        }

        public async Task<Artist> GetAnArtistAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return await db.Artists.FirstOrDefaultAsync(a => a.ArtistId == 1, cancellationToken);
            }
            var artist = await db.Artists.FirstOrDefaultAsync(a => a.ArtistId == id,cancellationToken);
            return artist;
        }
        public async Task<ArtistDto> CreateArtistAsync(ArtiArtistCreateDto CreateArtistDto, CancellationToken cancellationToken)
        {
            var newArtist = mapper.Map<Artist>(CreateArtistDto);
            db.Artists.Add(newArtist);
            await db.SaveChangesAsync(cancellationToken);
            var artistDto = mapper.Map<ArtistDto>(newArtist);
            return artistDto;
        }

        public async Task<Artist> UpdateAsync(Artist artist)
        {
            db.Artists.Update(artist);
            await db.SaveChangesAsync();
            return artist;
        }

        public async Task<ArtistDetailDto> DeleteArtistAsync(int id, CancellationToken cancellationToken)
        {
            var artist = await  db.Artists.FirstOrDefaultAsync(a => a.ArtistId == id, cancellationToken);
            db.Artists.Remove(artist);
            await db.SaveChangesAsync(cancellationToken);
            var artistDetailDto = mapper.Map<ArtistDetailDto>(artist);
            return artistDetailDto;
        }
    }
}
