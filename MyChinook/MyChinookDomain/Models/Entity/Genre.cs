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
    public class Genre : IConvertModel<Genre, GenreApiModel>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public GenreApiModel Convert() => new GenreApiModel
        {
            GenreId = GenreId,
            Name = Name
        };
    }
}
