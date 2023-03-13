using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{
    public interface IPlaylistRepository : IDisposable
    {
        Task<List<Playlist>> GetAllAsync(CancellationToken ct = default);
        Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default);
        Task<List<Track>> GetTrackByPlaylistIdAsync(int id, CancellationToken ct = default);
        Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
