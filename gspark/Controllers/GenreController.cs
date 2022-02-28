using AutoMapper;
using gspark.Domain.Models;
using gspark.Dtos.GenreDtos;
using gspark.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace gspark.API.Controllers;

[ApiController]
[Route("api/genres")]
public class GenreController : Controller
{
    private readonly IGenreRepository _repository;
    private readonly IMapper _mapper;

    public GenreController(IGenreRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IReadOnlyList<Genre>> GetAllGenresAsync()
    {
        return await _repository.GetAllGenresAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenreByIdAsync(int id)
    {
        return Ok(await _repository.GetGenreAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddGenreAsync(DtoCreateGenre dtoCreateGenre)
    {
        var entity = _mapper.Map<Genre>(dtoCreateGenre);
        return Ok(await _repository.AddGenreAsync(entity));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteGenreAsync(int id)
    {
        return Ok(_repository.DeleteGenre(id));
    }
}