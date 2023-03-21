using System.ComponentModel.DataAnnotations;

namespace MyChinook_Web.Models.Dtos
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
