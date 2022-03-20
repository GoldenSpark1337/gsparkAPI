using gspark.Domain.Models;

namespace gspark.Service.Contract;

public interface IBasketRepository
{
    Task<CustomerBasket> GetBasketAsync(string id);
    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string id);
}