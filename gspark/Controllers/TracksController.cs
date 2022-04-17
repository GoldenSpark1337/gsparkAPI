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

    public TracksController(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _fileService = fileService;
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
        
        var result = _fileService.AddFileAsync(file);
        if (result.Result.Error != null) return BadRequest(result.Result.Error.Message);

        var resultFile = new File()
        {
            Url = result.Result.Url.AbsoluteUri,
            PublicId = result.Result.PublicId,
            UserId = user.Id
        };

        await _unitOfWork.Repository<File>().AddEntityAsync(resultFile);
        dtoUpdateTrack.File = resultFile.Url;
        var entity = _mapper.Map(dtoUpdateTrack, track);
        
        _unitOfWork.Repository<Track>().Update(entity);
        if (await _unitOfWork.Complete())
        {
            return Ok();
        }
        return BadRequest("Failed to update");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrack(int id)
    {
        _unitOfWork.Repository<Track>().DeleteAsync(id);
        return NoContent();
    }
    
}