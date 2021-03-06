using gspark.Service.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}