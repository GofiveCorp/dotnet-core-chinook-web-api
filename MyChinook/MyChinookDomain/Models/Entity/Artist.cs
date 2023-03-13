using MyChinook.Models;
using MyChinookDomain.Models.ApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MyChinookDomain.Models.Entity
{
    public class Artist : IConvertModel<Artist, ArtistApiModel>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();

        public ArtistApiModel Convert() => new ArtistApiModel
        {
            ArtistId = ArtistId,
            Name = Name
        };
    }
}
