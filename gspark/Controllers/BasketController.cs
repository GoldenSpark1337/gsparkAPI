using gspark.Domain.Models;
using gspark.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class BasketController : BaseController
{
    private readonly IBasketRepository _basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
    {
        var basket = await _basketRepository.GetBasketAsync(id);

        return Ok(basket ?? new CustomerBasket(id));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
    {
        var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);

        return Ok(updatedBasket);
    }
    
    [HttpDelete]
    public async Task DeleteBasket(string id)
    {
        var updatedBasket = await _basketRepository.DeleteBasketAsync(id);
    }
}