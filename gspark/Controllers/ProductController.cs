using AutoMapper;
using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Service.Common.Pagination;
using gspark.Service.Contract;
using gspark.Service.Dtos.FileDtos;
using gspark.Service.Dtos.ProductDtos;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Mvc;
using File = gspark.Domain.Models.File;

namespace gspark.API.Controllers;

[Route("api/products")]
public class ProductController : BaseController
{
    private readonly IUnitOfWork _repo;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public ProductController(IUnitOfWork repo, IMapper mapper, IFileService fileService)
    {
        _repo = repo;
        _mapper = mapper;
        _fileService = fileService;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<DtoReturnProduct>>> GetAllProducts([FromQuery] ProductSpecParams productParams)
    {
        var spec = new ProductWithSpecification(productParams);
        var countSpec = new ProductWithCountSpecification(productParams);
        
        var totalItems = await _repo.Repository<Product>().CountAsync(countSpec);
        var entities = await _repo.Repository<Product>().ListAsync(spec);
        var data = _mapper.Map<IReadOnlyList<DtoReturnProduct>>(entities);
        
        return Ok(new Pagination<DtoReturnProduct>(productParams.PageIndex, 
            productParams.PageSize, totalItems, data));
    }

    [HttpGet("tracks")]
    public async Task<ActionResult<IReadOnlyList<DtoReturnTrack>>> GetAllTracks()
    {
        var spec = new ProductWithSpecification(new ProductSpecParams {Category = "Tracks"} );
        var entities = await _repo.Repository<Product>().ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnTrack>>(entities));
    }
    
    [HttpGet("services")]
    public async Task<ActionResult<IReadOnlyList<DtoReturnProduct>>> GetAllServices()
    {
        var spec = new ProductWithSpecification(new ProductSpecParams {Category = "Services"} );
        var entities = await _repo.Repository<Product>().ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnProduct>>(entities));
    }
    
    [HttpGet("kits")]
    public async Task<ActionResult<IReadOnlyList<DtoReturnProduct>>> GetAllKits()
    {
        var spec = new ProductWithSpecification(new ProductSpecParams {Category = "Kits"} );
        var entities = await _repo.Repository<Product>().ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnProduct>>(entities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DtoReturnProduct>> GetProduct(int id)
    {
        var spec = new ProductWithSpecification(id);
        var entity = await _repo.Repository<Product>().GetEntityWithSpecification(spec);
        return Ok(_mapper.Map<DtoReturnProduct>(entity));
    } 

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] DtoCreateProduct dtoCreateProduct)
    {
        var entity = _mapper.Map<Product>(dtoCreateProduct);
        return Ok(await _repo.Repository<Product>().AddEntityAsync(entity));
    }

    [HttpPost("add-image")]
    public async Task<ActionResult<DtoRetunFile>> AddProductImage(IFormFile file, int id)
    {
        var product = await _repo.Repository<Product>().GetByIdAsync(id);
        var result = await _fileService.AddImageAsync(file);

        if (result.Error != null) return BadRequest(result.Error.Message);

        var resultFile = new File()
        {
            Url = result.SecureUrl.AbsoluteUri,
            PublicId = result.PublicId
        };

        product.Image = resultFile.Url;
        Console.WriteLine(product.User.Files);
        product.Files.Add(resultFile);
        _repo.Repository<Product>().Update(product);
        if (await _repo.Complete())
        {
            return _mapper.Map<DtoRetunFile>(resultFile);
            // return CreatedAtRoute("GetUsername", new {}, _mapper.Map<DtoRetunFile>(resultFile));
        }
            
        return BadRequest("Problem adding image");
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
        _repo.Repository<Product>().DeleteAsync(id);
        return NoContent();
    }
}