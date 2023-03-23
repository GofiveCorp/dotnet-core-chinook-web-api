using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class PlaylistTable
    {
        public PlaylistTable(EntityTypeBuilder<Playlist> entity)
        {
            entity.Property(e => e.Name)
                  .HasMaxLength(200)
                  .IsRequired();
        }
    }
}
