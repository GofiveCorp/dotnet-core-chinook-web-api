using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.AddKeyToPlaylistTrack
{
    public class PlaylistTrackTable
    {
        public PlaylistTrackTable(EntityTypeBuilder<PlaylistTrack> entity)
        {
            entity.HasKey(e => new { e.PlaylistId, e.TrackId });
        }
    }
}
