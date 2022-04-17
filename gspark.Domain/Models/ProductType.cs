namespace gspark.Domain.Models;

public class ProductType : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}