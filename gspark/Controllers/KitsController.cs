using System.Security.Claims;
using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Contract;
using gspark.Service.Dtos.KitDtos;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class KitsController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public KitsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<DtoReturnKit>> GetKit([FromQuery] ProductSpecParams serviceParams, bool isDraft = false)
    {
        var spec = new ProductWithSpecification(serviceParams);
        var services = await _unitOfWork.Repository<Product>().ListAsync(spec);
        var serviceDraft = services.Where(x => x.IsDraft == isDraft).ToList();
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<DtoCreateKit>> AddKit(DtoCreateKit dtoCreateService)
    {
        var user = await _unitOfWork.UserRepository.GetUserByName(User.FindFirstValue(ClaimTypes.GivenName));
        dtoCreateService.UserId = user.Id;
        var entity = _mapper.Map<Product>(dtoCreateService);
        return Ok(await _unitOfWork.Repository<Product>().AddEntityAsync(entity));
    }
}