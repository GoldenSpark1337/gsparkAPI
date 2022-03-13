using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Dtos.ProductDtos;

public class DtoReturnUserQuickStats : IMapWith<Product>
{
    public int Id { get; set; }
    public decimal TotalNetSale { get; set; }
    public int NewFollowers { get; set; }
    public int Negotiations { get; set; }
    public int ActiveCampaigns { get; set; }
    public int Reposts { get; set; }
    public int Comments { get; set; }
    public int Plays { get; set; }
    public int FreeDownloads { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, DtoReturnUserQuickStats>();
    }
}