using AutoMapper;
using MyChinook.Models;
using MyChinook.Models.Dtos;

namespace MyChinook.Configures
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Album, AlbumDto>().ReverseMap();
            CreateMap<Artist, ArtistDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceLine, InvoiceLineDto>().ReverseMap();
            CreateMap<MediaType, MediaTypeDto>().ReverseMap();
            CreateMap<Playlist, PlaylistDto>().ReverseMap();
            CreateMap<Track, TrackDto>().ReverseMap();          
        }
    }
}
