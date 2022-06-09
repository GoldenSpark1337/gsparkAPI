using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Contract;
using gspark.Service.Dtos.KeyDtos;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class KeyController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public KeyController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnKey>>> GetKeys()
    {
        var keys = await _unitOfWork.Repository<Key>().GetAllAsync();
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnKey>>(keys));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DtoReturnKey>> GetKey(int id)
    {
        var key = await _unitOfWork.Repository<Key>().GetByIdAsync(id);
        return Ok(_mapper.Map<DtoReturnKey>(key));
    }
}