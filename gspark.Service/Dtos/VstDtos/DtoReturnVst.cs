using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.VstDtos;

public class DtoReturnVst : IMapWith<Vst>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Image { get; set; }
    public byte[]? File { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ProductType { get; set; }
    public string Publisher { get; set; }
    public string Version { get; set; }
    public string User { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Vst, DtoReturnVst>()
            .ForMember(dto => dto.Image,
                opt => opt.MapFrom(t =>
                    string.Format("{0}{1}", "http://localhost:5057/", t.User.Image)))
            .ForMember(dto => dto.User, 
                opt=> opt.MapFrom(v => v.User.UserName))
            .ForMember(dto => dto.ProductType, 
                opt=> opt.MapFrom(v => v.ProductType.Name));
    }
}