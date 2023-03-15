using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChinook.Models.Entities
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }

        [ForeignKey("MediaType")]
        public int MediaTypeId { get; set; }
        public MediaType MediaType { get; set; } = null!;

        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public Album Album { get; set; } = null!;

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }       
    }
}
