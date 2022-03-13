namespace gspark.Domain.Models;

public class ProductType : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}