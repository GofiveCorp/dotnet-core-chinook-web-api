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
    public class AlbumApiModel : IConvertModel<AlbumApiModel, Album>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string ArtistName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ArtistApiModel Artist { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IList<TrackApiModel> Tracks { get; set; }

        public Album Convert() => new Album
        {
            AlbumId = AlbumId,
            ArtistId = ArtistId,
            Title = Title
        };
    }
}
