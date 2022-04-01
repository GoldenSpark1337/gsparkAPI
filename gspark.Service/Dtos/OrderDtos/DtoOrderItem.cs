using AutoMapper;
using gspark.Domain.OrderAggregate;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.OrderDtos;

public class DtoOrderItem : IMapWith<OrderItem>
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderItem, DtoOrderItem>().ForMember(dto => dto.ProductId,
            opt => opt.MapFrom(oi => oi.ItemOrdered.ProductItemId)).ForMember(dto => dto.Title,
            opt => opt.MapFrom(oi => oi.ItemOrdered.Title)).ForMember(dto => dto.Image,
            opt => opt.MapFrom(oi => oi.ItemOrdered.Image));
        // ForMember(dto => dto.Image, 
        //     opt => opt.MapFrom<OrderItemUrlResolver>());
    }
}