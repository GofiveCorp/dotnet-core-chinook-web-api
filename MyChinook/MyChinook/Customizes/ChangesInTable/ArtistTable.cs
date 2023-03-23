using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class ArtistTable
    {
        public ArtistTable(EntityTypeBuilder<Artist> entity)
        {
            entity.Property(e => e.Name)
                  .HasMaxLength(200);
        }
    }
}
