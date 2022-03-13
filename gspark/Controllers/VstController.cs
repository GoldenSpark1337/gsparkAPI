using gspark.Domain.Models;
using gspark.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class VstController : BaseController
{
    private readonly IGenericRepository<Vst> _repo;

    public VstController(IGenericRepository<Vst> repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> AddVst([FromBody] Vst entity)
    {
        return Ok(await _repo.AddEntityAsync(entity));
    }
}