namespace gspark.Domain.OrderAggregate;

public class ProductItemOrdered
{
    public ProductItemOrdered()
    {
        
    }
    
    public ProductItemOrdered(int productItemId, string title, string image)
    {
        ProductItemId = productItemId;
        Title = title;
        Image = image;
    }
    
    public int ProductItemId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
}