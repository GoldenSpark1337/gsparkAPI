using System.Security.Claims;
using AutoMapper;
using BrunoZell.ModelBinding;
using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Mvc;
using File = gspark.Domain.Models.File;

namespace gspark.API.Controllers;

public class TracksController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly ILogger<TracksController> _logger;

    public TracksController(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService, ILogger<TracksController> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _fileService = fileService;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnTrack>>> GetAllTracks([FromQuery] TrackSpecParams trackParams, bool isDraft = false)
    {
        var spec = new TrackWithUsersSpecification(trackParams);
        var tracks = await _unitOfWork.Repository<Track>().ListAsync(spec);
        var tracksDraft = tracks.Where(x => x.IsDraft == isDraft).ToList();
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnTrack>>(tracksDraft));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DtoReturnTrack>> GetTrack(int id)
    {
        var spec = new TrackWithUsersSpecification(id);
        var track = await _unitOfWork.Repository<Track>().GetEntityWithSpecification(spec);
        return Ok(_mapper.Map<DtoReturnTrack>(track));
    }

    [HttpPost]
    public async Task<IActionResult> AddTrack(DtoCreateTrack dtoCreateTrack)
    {
        var user = await _unitOfWork.UserRepository.GetUserByName(User.FindFirstValue(ClaimTypes.GivenName));
        dtoCreateTrack.UserId = user.Id;
        var entity = _mapper.Map<Track>(dtoCreateTrack);
        return Ok(await _unitOfWork.Repository<Track>().AddEntityAsync(entity));
    }
    
    [HttpPut("edit/{id}")]
    public async Task<IActionResult> UpdateTrack([ModelBinder(BinderType = typeof(JsonModelBinder))] DtoUpdateTrack dtoUpdateTrack,
        int id, IFormFile file)
    {
        var user = await _unitOfWork.UserRepository.GetUserByName(User.FindFirstValue(ClaimTypes.GivenName));
        var track = await _unitOfWork.Repository<Track>().GetByIdAsync(id);
        
        var result = await _fileService.AddFileAsync(file);
        if (result.Error != null)
        {
            _logger.LogError(result.Error.Message);
            return BadRequest(result.Error.Message);
        }
        
        var resultFile = new File()
        {
            Url = result.Url.AbsoluteUri,
            PublicId = result.PublicId,
            UserId = user.Id
        };

        await _unitOfWork.Repository<File>().AddEntityAsync(resultFile);
        var deliveryUrl = await _fileService.DownloadFile(result);
        dtoUpdateTrack.File = deliveryUrl;
        var entity = _mapper.Map(dtoUpdateTrack, track);
        
        _unitOfWork.Repository<Track>().Update(entity);
        if (await _unitOfWork.Complete())
        {
            return Ok();
        }
        return BadRequest("Failed to update");
    }

    [HttpPatch("edit/{id}/plays")]
    public async Task<IActionResult> UpdateTrackPlays(int id)
    {
        var track = await _unitOfWork.Repository<Track>().GetByIdAsync(id);
        track.Plays++;
        _unitOfWork.Repository<Track>().Update(track);
        if (await _unitOfWork.Complete()) return Ok();

        return BadRequest("Failed to play audio");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrack(int id)
    {
        _unitOfWork.Repository<Track>().DeleteAsync(id);
        return NoContent();
    }
    
}