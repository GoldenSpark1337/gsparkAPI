using AutoMapper;
using gspark.Service.Common.Mappings;
using File = gspark.Domain.Models.File;

namespace gspark.Service.Dtos.FileDtos;

public class DtoRetunFile : IMapWith<File>
{
    public int Id { get; set; }
    public string Url { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<File, DtoRetunFile>();
    }
}