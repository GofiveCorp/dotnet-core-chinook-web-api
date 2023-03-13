using MyChinook.Models;
using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyChinookDomain.Models.ApiModel
{
    public class PlaylistTrackApiModel : IConvertModel<PlaylistTrackApiModel, PlaylistTrack>
    {

        public int PlaylistId { get; set; }

        public int TrackId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public PlaylistApiModel Playlist { get; set; }
        [NotMapped]
        [JsonIgnore]
        public TrackApiModel Track { get; set; }

        public PlaylistTrack Convert() => new PlaylistTrack
        {
            PlaylistId = PlaylistId,
            TrackId = TrackId
        };
    }
}
