using gspark.Domain.Models;
using gspark.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class RecordLabelController : BaseController
{
    private readonly IGenericRepository<RecordLabel> _repo;

    public RecordLabelController(IGenericRepository<RecordLabel> repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> AddRecordLAbel(RecordLabel entity)
    {
        return Ok(await _repo.AddEntityAsync(entity));
    }
    
}