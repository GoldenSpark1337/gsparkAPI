using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.GenreDtos;

public class DtoReturnGenre : IMapWith<Genre>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Genre, DtoReturnGenre>();
    }
}