﻿namespace MyChinook.Models.Dtos
{
    public class AlbumDto
    {
        public int AlbumId { get; set; }       
        public string Title { get; set; }     
        public ArtistDetailDto Artist { get; set; }
    }
}
