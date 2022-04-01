using gspark.Domain.Models;
using gspark.Domain.OrderAggregate;
using gspark.Service.Contract;
using gspark.Service.Specification;

namespace gspark.Service.Implementation;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBasketRepository _basketRepo;

    public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepo)
    {
        _unitOfWork = unitOfWork;
        _basketRepo = basketRepo;
    }
    
    public async Task<IReadOnlyList<Order>> GetOrdersAsync(string email)
    {
        var spec = new OrderWithSpecification(email);
        return await _unitOfWork.Repository<Order>().ListAsync(spec);
    }

    public async Task<Order> GetOrderAsync(int id, string email)
    {
        var spec = new OrderWithSpecification(id, email);
        return await _unitOfWork.Repository<Order>().GetEntityWithSpecification(spec);
    }

    public async Task<Order> CreateOrderAsync(string email, string cartId)
    {
        var basket = await _basketRepo.GetBasketAsync(cartId);

        var items = new List<OrderItem>();
        foreach (var item in basket.Items)
        {
            var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
            var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Title, productItem.Image);
            var orderItem = new OrderItem(itemOrdered, productItem.Price);
            items.Add(orderItem);
        }

        var subtotal = items.Sum(item => item.Price);

        var order = new Order(email, items, subtotal);

        _unitOfWork.Repository<Order>().Add(order);
        var result = await _unitOfWork.Complete();
        
        if (!result) return null;
        await _basketRepo.DeleteBasketAsync(cartId);

        return order;
    }
}