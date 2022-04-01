using System.Security.Claims;
using AutoMapper;
using gspark.Domain.OrderAggregate;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Dtos.OrderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

[Authorize]
public class OrdersController : BaseController
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnOrder>>> GetOrders()
    {
        var email = HttpContext.User?.FindFirstValue(ClaimTypes.Email);
        var orders = await _orderService.GetOrdersAsync(email);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnOrder>>(orders));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IReadOnlyList<DtoReturnOrder>>> GetOrders(int id)
    {
        var email = HttpContext.User?.FindFirstValue(ClaimTypes.Email);
        
        var order = await _orderService.GetOrderAsync(id, email);
        if (order == null) return NotFound(new ApiResponse(404));
        
        return Ok(_mapper.Map<DtoReturnOrder>(order));
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(DtoCreateOrder dtoCreateOrder)
    {
        var email = HttpContext.User?.FindFirstValue(ClaimTypes.Email);

        var order = await _orderService.CreateOrderAsync(email, dtoCreateOrder.BasketId);
        if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order"));
        
        return Ok(order);
    }
}