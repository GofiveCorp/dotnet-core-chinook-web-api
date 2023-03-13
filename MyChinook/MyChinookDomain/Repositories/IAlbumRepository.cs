﻿using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{
    public interface IAlbumRepository : IDisposable
    {
        Task<List<Album>> GetAllAsync(CancellationToken ct = default);
        Task<Album> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<Album>> GetByArtistIdAsync(int id, CancellationToken ct = default);
        Task<Album> AddAsync(Album newAlbum, CancellationToken ct = default);
        Task<bool> UpdateAsync(Album album, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
