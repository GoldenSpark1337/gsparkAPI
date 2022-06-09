using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Contract;
using gspark.Service.Dtos.GenreDtos;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace gspark.API.Controllers;

public class GenreController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenreController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnGenre>>> GetAllGenresAsync()
    {
        var genres =  await _unitOfWork.Repository<Genre>().GetAllAsync();
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnGenre>>(genres));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DtoReturnGenre>> GetGenreByIdAsync(int id)
    {
        var genre = await _unitOfWork.Repository<Genre>().GetByIdAsync(id);
        return Ok(_mapper.Map<DtoReturnGenre>(genre));
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddGenreAsync(DtoCreateGenre dtoCreateGenre)
    {
        var entity = _mapper.Map<Genre>(dtoCreateGenre);
        return Ok(await _unitOfWork.Repository<Genre>().AddEntityAsync(entity));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteGenreAsync(int id)
    {
        _unitOfWork.Repository<Genre>().DeleteAsync(id);
        return Ok();
    }
}