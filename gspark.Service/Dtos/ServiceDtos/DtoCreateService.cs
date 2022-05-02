using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.ServiceDtos;

public class DtoCreateService : IMapWith<Product>
{
    public string Title { get; set; } = "New Service";
    public string? Image { get; set; }
    public string? File { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public List<string> Tags { get; set; } = new List<string>() {""};
    public string Description { get; set; } = String.Empty;
    public int ProductTypeId { get; set; } = 3;
    public int UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoCreateService, Product>();
    }
}