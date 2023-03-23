using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChinook.Models.Entities
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }  
        public int MediaTypeId { get; set; }
        public MediaType MediaType { get; set; }      
        public int AlbumId { get; set; }
        public Album Album { get; set; }       
        public int GenreId { get; set; }
        public Genre Genre { get; set; } 
        public string Name { get; set; } 
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }
        //Relationship in Database
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new HashSet<PlaylistTrack>();
        public ICollection<InvoiceLine> InvoiceLines { get; set; } = new HashSet<InvoiceLine>();
    }
}
