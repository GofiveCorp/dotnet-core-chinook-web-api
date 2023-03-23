using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChinook.Models.Entities
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }  
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } 
        public string Title { get; set; }
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
