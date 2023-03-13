using MyChinook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using MyChinookDomain.Models.Entity;

namespace MyChinookDomain.Models.ApiModel
{
    public class ArtistApiModel : IConvertModel<ArtistApiModel, Artist>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IList<AlbumApiModel> Albums { get; set; }

        public Artist Convert() => new Artist
        {
            ArtistId = ArtistId,
            Name = Name
        };
    }
}
