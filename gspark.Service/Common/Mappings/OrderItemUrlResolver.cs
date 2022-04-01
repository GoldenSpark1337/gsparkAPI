using AutoMapper;
using gspark.Domain.OrderAggregate;
using gspark.Service.Dtos.OrderDtos;
using Microsoft.Extensions.Configuration;

namespace gspark.Service.Common.Mappings;

public class OrderItemUrlResolver : IValueResolver<OrderItem, DtoOrderItem, string>
{
    private readonly IConfiguration _configuration;

    public OrderItemUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string Resolve(OrderItem source, DtoOrderItem destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ItemOrdered.Image))
        {
            return _configuration["ApiUrl"] + source.ItemOrdered.Image;
        }

        return null;
    }
}