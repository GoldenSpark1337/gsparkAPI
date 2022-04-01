using gspark.Domain.Models;

namespace gspark.Service.Contract;

public interface IPaymentService
{ 
    Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
}