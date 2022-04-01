using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;
using gspark.Service.Dtos.UserDtos;

namespace gspark.Service.Dtos.ProductDtos;

public class DtoReturnProduct : IMapWith<Product>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string File { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    // public string Tags { get; set; }
    public string Description { get; set; }
    public string ProductType { get; set; }
    public string User { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, DtoReturnProduct>()
            .ForMember(dto => dto.Image,
                opt => opt.MapFrom(p => p.User.Image))
            .ForMember(dto => dto.ProductType, 
                opt => opt.MapFrom(p => p.ProductType.Name))
            .ForMember(dto => dto.User, 
                opt => opt.MapFrom(p => p.User.UserName));
    }
}