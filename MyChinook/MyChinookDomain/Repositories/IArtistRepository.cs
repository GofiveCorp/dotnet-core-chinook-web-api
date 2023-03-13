using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{
    public interface IArtistRepository : IDisposable
    {
        Task<List<Artist>> GetAllAsync(CancellationToken ct = default);
        Task<Artist> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default);
        Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
