using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.VstDtos;

public class DtoCreateVst : IMapWith<Vst>
{
    public string Title { get; set; }
    public string? Image { get; set; }
    public byte[]? File { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int ProductTypeId { get; set; }
    public string Publisher { get; set; }
    public string Version { get; set; }
    public int UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoCreateVst, Vst>();
    }
}