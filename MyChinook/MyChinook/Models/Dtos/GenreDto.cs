using MyChinook.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyChinook.Models.Dtos
{
    public class GenreDto
    {
        public int GenreId { get; set; }
 
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
