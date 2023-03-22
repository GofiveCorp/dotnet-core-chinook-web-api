using System.ComponentModel.DataAnnotations;

namespace MyChinook_Web.Models.Dtos
{
    public class TrackDto
    {      
        public int TrackId { get; set; }
        [Required]
        public string Name { get; set; } = null!;      
        public int MediaTypeId { get; set; }       
        public int AlbumId { get; set; }        
        public int GenreId { get; set; } 
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
