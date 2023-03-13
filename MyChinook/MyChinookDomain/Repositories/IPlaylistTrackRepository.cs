using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{
    public interface IPlaylistTrackRepository : IDisposable
    {
        Task<List<PlaylistTrack>> GetAllAsync(CancellationToken ct = default);
        Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int id, CancellationToken ct = default);
        Task<List<PlaylistTrack>> GetByTrackIdAsync(int id, CancellationToken ct = default);
        Task<PlaylistTrack> AddAsync(PlaylistTrack newPlaylistTrack, CancellationToken ct = default);
        Task<bool> UpdateAsync(PlaylistTrack playlistTrack, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
