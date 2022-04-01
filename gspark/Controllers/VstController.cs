using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Contract;
using gspark.Service.Dtos.VstDtos;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class VstController : BaseController
{
    private readonly IGenericRepository<Vst> _repo;
    private readonly IMapper _mapper;

    public VstController(IGenericRepository<Vst> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DtoReturnVst>>> AddVst([FromQuery] ProductSpecParams vstParams)
    {
        var spec = new VstSpecification(vstParams);
        var vsts = await _repo.ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<DtoReturnVst>>(vsts));
    }

    [HttpPost]
    public async Task<IActionResult> AddVst([FromBody] DtoCreateVst dtoCreateVst)
    {
        var vst = _mapper.Map<Vst>(dtoCreateVst);
        return Ok(await _repo.AddEntityAsync(vst));
    }
    
    [HttpPut("edit/{id}")]
    public async Task<IActionResult> EditVst(int id)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVst(int id)
    {
        _repo.DeleteAsync(id);
        return NoContent();
    }
}