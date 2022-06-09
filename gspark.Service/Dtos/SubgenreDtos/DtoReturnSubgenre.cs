using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.SubgenreDtos;

public class DtoReturnSubgenre : IMapWith<Subgenre>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Subgenre, DtoReturnSubgenre>()
            .ForMember(dto => dto.Genre,
                opt => opt.MapFrom(g => g.Genre.Name));
    }
}