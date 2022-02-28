using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Dtos.GenreDtos;

public class DtoCreateGenre : IMapWith<Genre>
{
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoCreateGenre, Genre>()
            .ForMember(genre => genre.Name,
                opt => opt.MapFrom(dtoGenre => dtoGenre.Name));
    }
}