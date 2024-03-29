﻿using MyChinook.Models;
using MyChinook.Models.Dtos;

namespace MyChinook.Repositories.IRepositories
{
    public interface IArtistRepository 
    {
        Task<List<Artist>> GetAllArtistsAsync(CancellationToken cancellationToken);
        Task<Artist> GetAnArtistAsync(int id, CancellationToken cancellationToken);   
        Task<ArtistDto> CreateArtistAsync(ArtiArtistCreateDto CreateArtistDto, CancellationToken cancellationToken);
        Task<ArtistDetailDto> UpdateAlbumAsync(int artistId, ArtistUpdateDto artistUpdateDto, CancellationToken cancellationToken);
        Task<ArtistDetailDto> DeleteArtistAsync(int id, CancellationToken cancellationToken);
    }
}
