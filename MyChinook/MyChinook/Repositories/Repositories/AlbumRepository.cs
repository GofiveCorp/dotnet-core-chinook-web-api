using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Models.Dtos;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MyChinookContext db;
        private readonly IMapper mapper;

        public AlbumRepository(MyChinookContext dbContext, IMapper mapper)
        {
            db = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<Album>> GetAllAlbumsAsync(CancellationToken cancellationToken)
        {
            var albums = await db.Albums.ToListAsync(cancellationToken);
            return albums;
        }

        public async Task<Album> GetAnAlbumAsync(int albumId, CancellationToken cancellationToken)
        {
            if (albumId == 0)
            {
                return await db.Albums.FirstOrDefaultAsync(a => a.AlbumId == 1, cancellationToken);
            }
            var album = await db.Albums.FirstOrDefaultAsync(a => a.AlbumId == 1, cancellationToken);
            return album;
        }


        public async Task<List<Album>> GetAlbumsByArtistAsync(int artistId, CancellationToken cancellationToken)
        {
            var albumsArtist = await db.Albums.Where(a => a.ArtistId == artistId).ToListAsync(cancellationToken);
            return albumsArtist;
        }
        public async Task<AlbumDto> CreateAlbumAsync(int artistId, AlbumCreateDto albumCreateDto, CancellationToken cancellationToken)
        {
            var albumCreate = mapper.Map<Album>(albumCreateDto);
            var artist = await GetAnArtist(artistId, cancellationToken);
            artist.Albums.Add(albumCreate);
            await db.SaveChangesAsync(cancellationToken);
            var albumDto = mapper.Map<AlbumDto>(albumCreate);
            return albumDto;
        }

        private async Task<Artist> GetAnArtist(int artistId, CancellationToken cancellationToken)
        {
            return await db.Artists.FirstOrDefaultAsync(a => a.ArtistId == artistId, cancellationToken);
        }

        public async Task<AlbumDeleteDto> DeleteAlbumAsync(int albumId, CancellationToken cancellationToken)
        {
            var album = await db.Albums.FirstOrDefaultAsync(a => a.AlbumId == albumId, cancellationToken);
            db.Albums.Remove(album);
            await db.SaveChangesAsync(cancellationToken);
            var artistDetailDto = mapper.Map<AlbumDeleteDto>(album);
            return artistDetailDto;
        }

        public async Task<AlbumDetailDto> UpdateAlbumAsync(int albumId, AlbumUpdateDto albumUpdateDto, CancellationToken cancellationToken)
        {

            var album = await db.Albums.FirstOrDefaultAsync(a => a.AlbumId == albumId, cancellationToken);
            var data = mapper.Map<Album>(album);
            data.ArtistId = albumUpdateDto.ArtistId;
            data.Title = albumUpdateDto.Title;        
            db.Albums.Update(data);
            await db.SaveChangesAsync(cancellationToken);
            var albumDetailDto = mapper.Map<AlbumDetailDto>(album);
            return albumDetailDto;
        }
    }
}
