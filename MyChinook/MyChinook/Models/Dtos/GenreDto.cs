namespace MyChinook.Models.Dtos
{
    public class GenreDto
    {
        public int GenreId { get; set; }
 
        public string Name { get; set; }
        public List<TrackDto> Tracks { get; set; }
    }
}
