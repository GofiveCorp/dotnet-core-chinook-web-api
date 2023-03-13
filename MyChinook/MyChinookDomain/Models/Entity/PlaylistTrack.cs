using MyChinook.Models;
using MyChinookDomain.Models.ApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyChinookDomain.Models.Entity
{
    public class PlaylistTrack : IConvertModel<PlaylistTrack, PlaylistTrackApiModel>
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Playlist Playlist { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Track Track { get; set; }

        public PlaylistTrackApiModel Convert() => new PlaylistTrackApiModel
        {
            PlaylistId = PlaylistId,
            TrackId = TrackId
        };
    }
}
