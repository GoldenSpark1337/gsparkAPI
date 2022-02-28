using AutoMapper;
using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Service.Contract;
using gspark.Service.Implementation;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

[ApiController]
[Route("api/tracks")]
public class TracksController : Controller
{
    private readonly ITrackRepository _repository;
    private readonly IGenericRepository<Track> _repo;
    private readonly IMapper _mapper;

    public TracksController(ITrackRepository repository, IGenericRepository<Track> repo, IMapper mapper)
    {
        _repository = repository;
        _repo = repo;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnTrack>>> GetAllTracks()
    {
        var spec = new TrackWithUsersSpecification();
        var tracks = await _repo.ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnTrack>>(tracks));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrack(int id)
    {
        var spec = new TrackWithUsersSpecification(id);
        var track = await _repo.GetEntityWithSpecification(spec);
        return Ok(_mapper.Map<DtoReturnTrack>(track));
    }

    [HttpPost]
    public async Task<IActionResult> AddTrack([FromBody] DtoCreateTrack dtoCreateTrack)
    {
        var entity = _mapper.Map<Track>(dtoCreateTrack);
        return Ok(await _repository.AddTrack(entity));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrack(int id)
    {
        return Ok(_repository.DeleteTrack(id));
    }
    
}