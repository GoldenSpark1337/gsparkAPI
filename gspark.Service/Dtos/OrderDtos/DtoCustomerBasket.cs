namespace gspark.Service.Dtos.OrderDtos;

public class DtoCustomerBasket
{
    public string Id { get; set; }
    // public List<B> Items { get; set; }
    public string ClientSecret { get; set; }
    public string PaymentIntentId { get; set; }
}