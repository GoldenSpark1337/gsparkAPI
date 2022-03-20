namespace gspark.Domain.Models;

public class ProductTags
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public int TagId { get; set; }
    public virtual Tag Tag { get; set; }
}