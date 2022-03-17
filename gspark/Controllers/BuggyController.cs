using gspark.Repository;
using gspark.Service.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

public class BuggyController : BaseController
{
    private readonly MarketPlaceContext _cont;

    public BuggyController(MarketPlaceContext cont)
    {
        _cont = cont;
    }
    [HttpGet("notfound")]
    public IActionResult GetNotFoundError()
    {
        return NotFound(new ApiResponse(404));
    }

    [HttpGet("test")]
    [Authorize]
    public IActionResult Niggas()
    {
        return Ok("secret stuff");
    }

    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        return BadRequest(new ApiResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public IActionResult GetNotFoundReqest(int id)
    {
        return Ok();
    }

    [HttpGet("servererror")]
    public ActionResult<string> GetServerError()
    {
        var xd = _cont.Products.FindAsync(-1);
        var thingtoReturn = xd.ToString();
        return thingtoReturn;
    }
}