using System.Text.Json;
using System.Text.Json.Nodes;
using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.ProductDtos;

public class DtoCreateProduct : IMapWith<Product>
{
    public string Title { get; set; } = "New Product";
    public string? Image { get; set; }
    public string? File { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public List<Tag> Tags { get; set; }
    public string Description { get; set; }
    public int ProductTypeId { get; set; }
    public int UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoCreateProduct, Product>();
    }
}