namespace gspark.Domain.Models;

public class CustomerBasket
{
    public CustomerBasket() {}
    
    public CustomerBasket(string id)
    {
        Id = id;
    }
    
    public string Id { get; set; }
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    // public string ClientSecret { get; set; }
    // public string PaymentIntentId { get; set; }
}