using AutoMapper;
using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class TracksController : BaseController
{
    private readonly IGenericRepository<Track> _repo;
    private readonly IMapper _mapper;

    public TracksController(IGenericRepository<Track> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnTrack>>> GetAllTracks([FromQuery] TrackSpecParams trackParams)
    {
        var spec = new TrackWithUsersSpecification(trackParams);
        var tracks = await _repo.ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnTrack>>(tracks));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DtoReturnTrack>> GetTrack(int id)
    {
        var spec = new TrackWithUsersSpecification(id);
        var track = await _repo.GetEntityWithSpecification(spec);
        return Ok(_mapper.Map<DtoReturnTrack>(track));
    }

    [HttpPost]
    public async Task<IActionResult> AddTrack([FromBody] DtoCreateTrack dtoCreateTrack)
    {
        var entity = _mapper.Map<Track>(dtoCreateTrack);
        return Ok(await _repo.AddEntityAsync(entity));
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> EditTrack(int id)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrack(int id)
    {
        return Ok(_repo.DeleteAsync(id));
    }
    
}