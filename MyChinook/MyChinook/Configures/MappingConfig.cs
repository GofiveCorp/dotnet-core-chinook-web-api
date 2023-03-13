using AutoMapper;
using MyChinook.Models.Dtos;
using MyChinook.Models.Entities;

namespace MyChinook.Configures
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Invoice, InvoiceDto>().ReverseMap();

            CreateMap<InvoiceLine, InvoiceLineDto>().ReverseMap();

            CreateMap<Artist, ArtistDto>().ReverseMap();

            CreateMap<Album, AlbumDto>().ReverseMap();

            CreateMap<MediaType, MediaTypeDto>().ReverseMap();  

            CreateMap<Genre, GenreDto>().ReverseMap();  

            CreateMap<Track, TrackDto>().ReverseMap();  

            CreateMap<Playlist, PlaylistDto>().ReverseMap();
        }
    }
}
