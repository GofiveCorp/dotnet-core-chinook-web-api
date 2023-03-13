using Microsoft.EntityFrameworkCore;
using MyChinookDomain.Models.Entity;
using MyChinookDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinook.DataEFCore.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ChinookContext _context;

        public ArtistRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> ArtistExists(int id, CancellationToken ct = default) =>
            await _context.Artist.AnyAsync(a => a.ArtistId == id, ct);

        public void Dispose() => _context.Dispose();

        public async Task<List<Artist>> GetAllAsync(CancellationToken ct = default) =>
            await _context.Artist.AsNoTracking().ToListAsync(ct);

        public async Task<Artist> GetByIdAsync(int id, CancellationToken ct = default) =>
            await _context.Artist.FindAsync(id);

        public async Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default)
        {
            _context.Artist.Add(newArtist);
            await _context.SaveChangesAsync(ct);
            return newArtist;
        }

        public async Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default)
        {
            if (!await ArtistExists(artist.ArtistId, ct))
                return false;
            _context.Artist.Update(artist);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            if (!await ArtistExists(id, ct))
                return false;
            var toRemove = _context.Artist.Find(id);
            _context.Artist.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
