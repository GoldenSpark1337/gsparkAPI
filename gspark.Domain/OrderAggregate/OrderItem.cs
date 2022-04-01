using gspark.Domain.Models;

namespace gspark.Domain.OrderAggregate;

public class OrderItem : BaseEntity
{
    // Parameterless constructor for entityframework migration
    public OrderItem() {}
    
    public OrderItem(ProductItemOrdered itemOrdered, decimal price)
    {
        ItemOrdered = itemOrdered;
        Price = price;
    }

    public ProductItemOrdered ItemOrdered { get; set; }
    public decimal Price { get; set; }
}