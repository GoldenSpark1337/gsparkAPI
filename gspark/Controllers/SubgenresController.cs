using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Contract;
using gspark.Service.Dtos.SubgenreDtos;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class SubgenresController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubgenresController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnSubgenre>>> GetSubgenres()
    {
        var subgenres = await _unitOfWork.Repository<Subgenre>().GetAllAsync();
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnSubgenre>>(subgenres));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DtoReturnSubgenre>> GetSubgenre(int id)
    {
        var subgenre = await _unitOfWork.Repository<Subgenre>().GetByIdAsync(id);
        return Ok(_mapper.Map<DtoReturnSubgenre>(subgenre));
    }
}