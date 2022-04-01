using gspark.Domain.OrderAggregate;

namespace gspark.Service.Contract;

public interface IOrderService
{
    Task<IReadOnlyList<Order>> GetOrdersAsync(string email);
    Task<Order> GetOrderAsync(int id, string email);
    Task<Order> CreateOrderAsync(string email, string cartId);
}