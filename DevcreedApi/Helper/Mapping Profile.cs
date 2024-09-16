using AutoMapper;
using DevcreedApi.DTOS;
using DevcreedApi.Models;

namespace DevcreedApi.Helper
{
    public class Mapping_Profile : Profile
    {
        public Mapping_Profile()
        {
            CreateMap<Movie, MovieDetailsDto>();

            CreateMap<CreateMovieDto, Movie>().ForMember(src => src.Poster, opt => opt.Ignore());

            CreateMap<UpdateMovieDto, Movie>().ForMember(dest => dest.Poster, opt => opt.Ignore());
        }
    }
}
