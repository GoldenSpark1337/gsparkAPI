using System.Collections;

namespace gspark.Service.Common.Exceptions;

public class ApiValidationErrorResponse : ApiResponse
{
    public ApiValidationErrorResponse() : base(400)
    {
    }

    public IEnumerable<string> Errors { get; set; }
}