using Microsoft.Build.Framework;

namespace MyChinook.Models.Dtos
{
    public class AlbumDto
    {

        public int AlbumId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        
        public int ArtistId { get; set; }
    }
}
