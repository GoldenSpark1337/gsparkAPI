using AutoMapper;
using gspark.Domain.Models;
using gspark.Dtos.ProductDtos;
using gspark.Service.Contract;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

[Route("api/products")]
public class ProductController : BaseController
{
    private readonly IGenericRepository<Product> _repo;
    private readonly IMapper _mapper;

    public ProductController(IGenericRepository<Product> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnProduct>>> GetAllProducts([FromQuery] ProductSpecParams productParams)
    {
        var spec = new ProductWithSpecification(productParams);
        var entities = await _repo.ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnProduct>>(entities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DtoReturnProduct>> GetProduct(int id)
    {
        // var spec = new ProductWithSpecification(id);
        var entity = await _repo.GetByIdAsync(id);
        return Ok(_mapper.Map<DtoReturnProduct>(entity));
    } 

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] DtoCreateProduct dtoCreateProduct)
    {
        var entity = _mapper.Map<Product>(dtoCreateProduct);
        return Ok(await _repo.AddEntityAsync(entity));
    }
    
    [HttpPut("edit/{id}")]
    public async Task<IActionResult> EditProduct(int id)
    {
        return Ok();
    }

    [HttpPut("edit/{id}/image/{imageId}")]
    public async Task<IActionResult> AddProductImage(int id, int imageId)
    {
        return Ok();
    }

    [HttpDelete("edit/{id}/image/{imageId}")]
    public async Task<IActionResult> DeleteProductImage(int id, int imageId)
    {
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return Ok(_repo.DeleteAsync(id));
    }
}