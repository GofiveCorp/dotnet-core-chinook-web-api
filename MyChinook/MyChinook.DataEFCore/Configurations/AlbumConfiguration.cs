using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinook.DataEFCore.Configurations
{
    public class AlbumConfiguration
    {
        public AlbumConfiguration(EntityTypeBuilder<Album> entity)
        {
            entity.HasIndex(e => e.ArtistId)
                .HasName("IFK_Artist_Album");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(160);

            entity.HasOne(d => d.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Album__ArtistId__276EDEB3");
        }
    }
}
