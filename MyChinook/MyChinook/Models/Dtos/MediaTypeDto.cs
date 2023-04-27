namespace MyChinook.Models.Dtos
{
    public class MediaTypeDto
    {      
        public int MediaTypeId { get; set; }
     
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
