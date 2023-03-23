using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class PlaylistTrackTable
    {
        public PlaylistTrackTable(EntityTypeBuilder<PlaylistTrack> entity)
        {
            entity.HasKey(e => new { e.PlaylistId, e.TrackId });
            entity.HasOne(p => p.Playlist)
                  .WithMany(p => p.PlaylistTracks)
                  .HasForeignKey(p => p.PlaylistId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Track)
                  .WithMany(p => p.PlaylistTracks)
                  .HasForeignKey(p => p.TrackId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(p => p.PlaylistId);               
            entity.HasIndex(p => p.TrackId);
        }
    }
}
