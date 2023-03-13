
using System.ComponentModel.DataAnnotations;

namespace MyChinook.Models.Dtos
{
    public class ArtistDto
    {

        public int ArtistId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
