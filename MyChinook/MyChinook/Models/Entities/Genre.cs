using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChinook.Models.Entities
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
