using gspark.Domain.Models;

namespace gspark.Domain.OrderAggregate;

public class Order : BaseEntity
{
    public Order() {}
    
    public Order(string email, IReadOnlyList<OrderItem> orderItems, decimal total)
    {
        Email = email;
        OrderItems = orderItems;
        Total = total;
    }

    public string Email { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public IReadOnlyList<OrderItem> OrderItems { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string? PaymentIntentId { get; set; }
    public decimal Total { get; set; }
}