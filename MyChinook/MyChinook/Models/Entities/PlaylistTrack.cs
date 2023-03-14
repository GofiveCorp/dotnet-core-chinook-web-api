using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChinook.Models.Entities
{
    public class PlaylistTrack
    {
              
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    
        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
