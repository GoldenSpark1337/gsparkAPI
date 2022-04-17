using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Contract;
using gspark.Service.Dtos.VstDtos;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class VstController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VstController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnVst>>> AddVst([FromQuery] ProductSpecParams vstParams)
    {
        var spec = new VstSpecification(vstParams);
        var vsts = await _unitOfWork.Repository<Vst>().ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnVst>>(vsts));
    }

    [Authorize(Policy = "ProPage")]
    [HttpPost]
    public async Task<IActionResult> AddVst([FromBody] DtoCreateVst dtoCreateVst)
    {
        var vst = _mapper.Map<Vst>(dtoCreateVst);
        return Ok(await _unitOfWork.Repository<Vst>().AddEntityAsync(vst));
    }
    
    [Authorize(Policy = "ProPage")]
    [HttpPut("edit/{id}")]
    public async Task<IActionResult> EditVst(int id)
    {
        return Ok();
    }

    [Authorize(Policy = "ProPage")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVst(int id)
    {
        _unitOfWork.Repository<Vst>().DeleteAsync(id);
        return NoContent();
    }
}