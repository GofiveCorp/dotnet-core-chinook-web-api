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
    public class GenreRepository : IGenreRepository
    {
        private readonly ChinookContext _context;

        public GenreRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> GenreExists(int id, CancellationToken ct = default) =>
            await _context.Genre.AnyAsync(g => g.GenreId == id, ct);

        public void Dispose() => _context.Dispose();

        public async Task<List<Genre>> GetAllAsync(CancellationToken ct = default) =>
            await _context.Genre.AsNoTracking().ToListAsync(ct);

        public async Task<Genre> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var dbGenre = await _context.Genre.FindAsync(id);
            return dbGenre;
        }

        public async Task<Genre> AddAsync(Genre newGenre, CancellationToken ct = default)
        {
            _context.Genre.Add(newGenre);
            await _context.SaveChangesAsync(ct);
            return newGenre;
        }

        public async Task<bool> UpdateAsync(Genre genre, CancellationToken ct = default)
        {
            if (!await GenreExists(genre.GenreId, ct))
                return false;
            _context.Genre.Update(genre);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            if (!await GenreExists(id, ct))
                return false;
            var toRemove = _context.Genre.Find(id);
            _context.Genre.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
