using Microsoft.EntityFrameworkCore;
using MyChinook.DataEFCoreCmpldQry;
using MyChinookDomain.Models.Entity;
using MyChinookDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataEFCoreCmpldQry.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ChinookContext _context;

        public PlaylistRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> PlaylistExists(int id, CancellationToken ct = default) =>
            await _context.Playlist.AnyAsync(i => i.PlaylistId == id, ct);

        public void Dispose() => _context.Dispose();

        public async Task<List<Playlist>> GetAllAsync(CancellationToken ct = default)
            => await _context.GetAllPlaylistsAsync();

        public async Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var playlist = await _context.GetPlaylistAsync(id);
            return playlist.First();
        }

        public async Task<List<Track>> GetTrackByPlaylistIdAsync(int id,
            CancellationToken ct = default)
        {
            IList<Track> list = new List<Track>();
            var playlistTracks = _context.PlaylistTrack.Where(p => p.PlaylistId == id);
            foreach (var playlistTrack in playlistTracks)
            {
                var track = await _context.Track.FindAsync(playlistTrack.TrackId);
                list.Add(track);
            }

            return list.ToList();
        }

        public async Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default)
        {
            _context.Playlist.Add(newPlaylist);
            await _context.SaveChangesAsync(ct);
            return newPlaylist;
        }

        public async Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default)
        {
            if (!await PlaylistExists(playlist.PlaylistId, ct))
                return false;
            _context.Playlist.Update(playlist);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            if (!await PlaylistExists(id, ct))
                return false;
            var toRemove = _context.Playlist.Find(id);
            _context.Playlist.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
