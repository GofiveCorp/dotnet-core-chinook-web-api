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
    public class TrackRepository : ITrackRepository
    {
        private readonly ChinookContext _context;

        public TrackRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> TrackExists(int id, CancellationToken ct = default) =>
            await _context.Track.AnyAsync(i => i.TrackId == id, ct);

        public void Dispose() => _context.Dispose();

        public async Task<List<Track>> GetAllAsync(CancellationToken ct = default) =>
            await _context.Track.AsNoTracking().ToListAsync(ct);

        public async Task<Track> GetByIdAsync(int id, CancellationToken ct = default) =>
            await _context.Track.FindAsync(id);

        public async Task<Track> AddAsync(Track newTrack, CancellationToken ct = default)
        {
            _context.Track.Add(newTrack);
            await _context.SaveChangesAsync(ct);
            return newTrack;
        }

        public async Task<bool> UpdateAsync(Track track, CancellationToken ct = default)
        {
            if (!await TrackExists(track.TrackId, ct))
                return false;
            _context.Track.Update(track);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            if (!await TrackExists(id, ct))
                return false;
            var toRemove = _context.Track.Find(id);
            _context.Track.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default) =>
            await _context.Track.Where(a => a.AlbumId == id).ToListAsync(ct);

        public async Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default) =>
            await _context.Track.Where(a => a.GenreId == id).ToListAsync(ct);

        public async Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default) =>
            await _context.Track.Where(a => a.MediaTypeId == id).ToListAsync(ct);
    }
}
