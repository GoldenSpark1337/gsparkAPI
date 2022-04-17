using gspark.Domain.Models;

namespace gspark.Domain.OrderAggregate;

public class OrderItem : IBaseEntity
{
    // Parameterless constructor for entityframework migration
    public OrderItem() {}
    
    public OrderItem(ProductItemOrdered itemOrdered, decimal price)
    {
        ItemOrdered = itemOrdered;
        Price = price;
    }

    public int Id { get; set; }
    public ProductItemOrdered ItemOrdered { get; set; }
    public decimal Price { get; set; }
}