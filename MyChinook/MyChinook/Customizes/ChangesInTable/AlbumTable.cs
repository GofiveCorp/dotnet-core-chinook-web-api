using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class AlbumTable
    {
        public AlbumTable(EntityTypeBuilder<Album> entity)
        {
            entity.HasIndex(e => e.ArtistId);          
            entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(200);
            entity.HasOne(d => d.Artist)
                  .WithMany(p => p.Albums)
                  .HasForeignKey(d => d.ArtistId)
                  .OnDelete(DeleteBehavior.Restrict);       
        }
    }
}
