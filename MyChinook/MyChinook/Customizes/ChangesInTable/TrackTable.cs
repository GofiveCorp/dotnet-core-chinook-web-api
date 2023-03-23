using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class TrackTable
    {
        public TrackTable(EntityTypeBuilder<Track> entity)
        {
            entity.HasIndex(e => e.AlbumId);
            entity.HasIndex(e => e.GenreId);
            entity.HasIndex(e => e.MediaTypeId);
            entity.Property(e => e.Composer).HasMaxLength(200);
            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(200);
            entity.Property(e => e.UnitPrice);
            entity.HasOne(d => d.Album)
                  .WithMany(p => p.Tracks)
                  .HasForeignKey(d => d.AlbumId);
            entity.HasOne(d => d.Genre)
                  .WithMany(p => p.Tracks)
                  .HasForeignKey(d => d.GenreId);
            entity.HasOne(d => d.MediaType)
                  .WithMany(p => p.Tracks)
                  .HasForeignKey(d => d.MediaTypeId)
                  .OnDelete(DeleteBehavior.Restrict);             
        }
    }
}
