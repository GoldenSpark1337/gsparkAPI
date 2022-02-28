namespace gspark.Domain.Models;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
}