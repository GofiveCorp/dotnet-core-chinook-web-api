using AutoMapper;
using MyChinook.Models;
using MyChinook.Models.Dtos;

namespace MyChinook.Configures
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Album, AlbumDto>()
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => new ArtistDetailDto
                {
                    Name = src.Artist.Name
                }))
                .ReverseMap();
            CreateMap<Artist, ArtistDto>()
                .ReverseMap();
            CreateMap<Customer, CustomerDto>()
                .ReverseMap();
            CreateMap<Employee, EmployeeDto>()
                .ReverseMap();
            CreateMap<Genre, GenreDto>()
                .ReverseMap();
            CreateMap<Invoice, InvoiceDto>()
                .ReverseMap();
            CreateMap<InvoiceLine, InvoiceLineDto>()
                .ReverseMap();
            CreateMap<MediaType, MediaTypeDto>()
                .ReverseMap();
            CreateMap<Playlist, PlaylistDto>()
                .ReverseMap();
            CreateMap<Track, TrackDto>()
                .ReverseMap();

            CreateMap<AlbumCreateDto, Album>()
                .ReverseMap();
            CreateMap<AlbumDetailDto, Album>()
               .ReverseMap();        
            CreateMap<Artist, ArtistDetailDto>()
                .ReverseMap();
            CreateMap<ArtiArtistCreateDto, Artist>()
                .ReverseMap();
            CreateMap<Album, AlbumDeleteDto>()             
                .ReverseMap();
            CreateMap<Album, AlbumUpdateDto>()
              .ReverseMap();
            

        }
    }
}
