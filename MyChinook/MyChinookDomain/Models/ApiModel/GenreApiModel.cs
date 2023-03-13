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
    public class GenreApiModel : IConvertModel<GenreApiModel, Genre>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IList<TrackApiModel> Tracks { get; set; }

        public Genre Convert() => new Genre
        {
            GenreId = GenreId,
            Name = Name
        };
    }
}
