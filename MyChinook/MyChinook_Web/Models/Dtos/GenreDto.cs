using System.ComponentModel.DataAnnotations;

namespace MyChinook_Web.Models.Dtos
{
    public class GenreDto
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; } 
    }
}
