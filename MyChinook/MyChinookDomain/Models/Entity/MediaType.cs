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
    public class MediaType : IConvertModel<MediaType, MediaTypeApiModel>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MediaTypeId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public MediaTypeApiModel Convert() => new MediaTypeApiModel
        {
            MediaTypeId = MediaTypeId,
            Name = Name
        };
    }
}
