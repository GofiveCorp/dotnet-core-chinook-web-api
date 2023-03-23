using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class MediaTypeTable
    {
        public MediaTypeTable(EntityTypeBuilder<MediaType> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        }
    }
}
