using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{
    public interface ITrackRepository : IDisposable
    {
        Task<List<Track>> GetAllAsync(CancellationToken ct = default);
        Task<Track> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default);
        Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default);
        Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default);
        Task<Track> AddAsync(Track newTrack, CancellationToken ct = default);
        Task<bool> UpdateAsync(Track track, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
