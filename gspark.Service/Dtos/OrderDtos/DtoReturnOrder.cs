using AutoMapper;
using gspark.Domain.OrderAggregate;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.OrderDtos;

public class DtoReturnOrder : IMapWith<Order>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public IReadOnlyList<DtoOrderItem> OrderItems { get; set; }
    public string Status { get; set; }
    public decimal Total { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, DtoReturnOrder>();
    }
}