using System.Linq.Expressions;
using gspark.Domain.OrderAggregate;

namespace gspark.Service.Specification;

public class OrderWithSpecification : BaseSpecification<Order>
{
    public OrderWithSpecification(string email) : base(o => o.Email == email)
    {
        AddInclude(o => o.OrderItems);
        AddOrderByDescending(o => o.OrderDate);
    }

    public OrderWithSpecification(int id, string email) 
        : base(o => o.Id == id && o.Email == email)
    {
        AddInclude(o => o.OrderItems);
    }
}