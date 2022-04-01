namespace gspark.Domain.Models;

public class BasketItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string Type { get; set; }
    public string User { get; set; }
}