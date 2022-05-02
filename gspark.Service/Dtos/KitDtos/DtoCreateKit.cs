using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.KitDtos;

public class DtoCreateKit : IMapWith<Product>
{
    public string Title { get; set; } = "New Kit";
    public string? Image { get; set; }
    public string? File { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public List<string> Tags { get; set; } = new List<string>() {""};
    public string Description { get; set; } = String.Empty;
    public int ProductTypeId { get; set; } = 2;
    public int UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoCreateKit, Product>();
    }
}