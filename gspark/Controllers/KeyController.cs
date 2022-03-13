using gspark.Domain.Models;
using gspark.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class KeyController : BaseController
{
    private readonly IGenericRepository<Key> _repo;

    public KeyController(IGenericRepository<Key> repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Key>>> GetKeys()
    {
        return Ok(await _repo.GetAllAsync());
    }
}