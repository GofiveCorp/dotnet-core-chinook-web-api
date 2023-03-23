using Microsoft.Build.Framework;

namespace MyChinook.Models.Dtos
{
    public class AlbumDto
    {
        public int AlbumId { get; set; }
        [Required]
        public string Title { get; set; }     
        public int ArtistId { get; set; }
        public ArtistDto Artist { get; set; }
    }
}
