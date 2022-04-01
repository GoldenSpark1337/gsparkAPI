using gspark.Domain.Models;
using gspark.Service.Contract;
using Microsoft.Extensions.Configuration;
using Stripe;
using Product = gspark.Domain.Models.Product;

namespace gspark.Service.Implementation;

public class PaymentService : IPaymentService
{
    private readonly IBasketRepository _basketRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public PaymentService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _basketRepository = basketRepository;
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }
    
    public async Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
    {
        StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];
        
        var basket = await _basketRepository.GetBasketAsync(basketId);

        foreach (var item in basket.Items)
        {
            var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
            if (item.Price != productItem.Price)
            {
                item.Price = productItem.Price;
            }
        }

        var service = new PaymentIntentService();
        PaymentIntent intent;
        // if (string.IsNullOrEmpty(basket.PaymentIntentId))
        // {
        //     var options = new PaymentIntentCreateOptions
        //     {
        //         Amount = (long) basket.Items.Sum(i => (i.Price * 100)),
        //         Currency = "usd",
        //         PaymentMethodTypes = new List<string> {"card"}
        //     };
        //     intent = await service.CreateAsync(options);
        //     basket.PaymentIntentId = intent.Id;
        //     basket.ClientSecret = intent.ClientSecret;
        // }
        // else
        // {
        //     var options = new PaymentIntentUpdateOptions
        //     {
        //         Amount = (long) basket.Items.Sum(i => (i.Price * 100))
        //     };
        //     await service.UpdateAsync(basket.PaymentIntentId, options);
        // }
        //
        // await _basketRepository.UpdateBasketAsync(basket);

        return basket;
    }
}