using System.Text.Json.Nodes;
using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Dtos.ProductDtos;

public class DtoCreateProduct : IMapWith<Product>
{
    public string Title { get; set; }
    public string? Image { get; set; }
    public byte[]? File { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public JsonValue Tags { get; set; }
    public string Description { get; set; }
    public int ProductTypeId { get; set; }
    public int UserId { get; set; }
    public int? VstId { get; set; }
    public int? TrackId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoCreateProduct, Product>();
    }
}