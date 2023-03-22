using System.ComponentModel.DataAnnotations;

namespace MyChinook.Models.Dtos
{
    public class GenreDto
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
