using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.LeasingDtos;

public class DtoCreateLeasing : IMapWith<Leasing>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public int UserId { get; set; }
    public string Streams { get; set; }
    public string Copies { get; set; }
    public string TrackType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoCreateLeasing, Leasing>();
    }
}