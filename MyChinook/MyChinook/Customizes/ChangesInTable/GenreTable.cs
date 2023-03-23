using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class GenreTable
    {
        public GenreTable(EntityTypeBuilder<Genre> entity)
        {
            entity.Property(e => e.Name)
                  .HasMaxLength(200);
        }
    }
}
