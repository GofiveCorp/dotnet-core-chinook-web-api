namespace MyChinook.Models.Dtos
{
    public class PlaylistDto
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public IList<PlaylistTrackDto> PlaylistTrack { get; set; }
    }
}
