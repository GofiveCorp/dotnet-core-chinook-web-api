using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChinook.Models.Entities
{
    public class MediaType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
