using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.KeyDtos;

public class DtoReturnKey : IMapWith<Key>
{
    public int Id { get; set; }
    public string Track_Key { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Key, DtoReturnKey>();
    }
}