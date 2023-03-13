﻿using Microsoft.EntityFrameworkCore;
using MyChinookDomain.Models.Entity;
using MyChinookDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinook.DataEFCore.Repositories
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        private readonly ChinookContext _context;

        public MediaTypeRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> MediaTypeExists(int id, CancellationToken ct = default) =>
            await _context.MediaType.AnyAsync(i => i.MediaTypeId == id, ct);

        public void Dispose() => _context.Dispose();

        public async Task<List<MediaType>> GetAllAsync(CancellationToken ct = default) =>
            await _context.MediaType.AsNoTracking().ToListAsync(ct);

        public async Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default) =>
            await _context.MediaType.FindAsync(id);

        public async Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default)
        {
            _context.MediaType.Add(newMediaType);
            await _context.SaveChangesAsync(ct);
            return newMediaType;
        }

        public async Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default)
        {
            if (!await MediaTypeExists(mediaType.MediaTypeId, ct))
                return false;
            _context.MediaType.Update(mediaType);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            if (!await MediaTypeExists(id, ct))
                return false;
            var toRemove = _context.MediaType.Find(id);
            _context.MediaType.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
