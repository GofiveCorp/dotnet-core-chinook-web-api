namespace MyChinook.Models.Dtos
{
    public class PlaylistTrackDto
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        public PlaylistDto Playlist { get; set; }        
        public TrackDto Track { get; set; } 
    }
}

