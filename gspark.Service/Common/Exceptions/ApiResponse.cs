namespace gspark.Service.Common.Exceptions;

public class ApiResponse
{
    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad request",
            401 => "You are not authorized",
            403 => "You don't have permission",
            404 => "Resource not found",
            500 => "Internal server error",
            _ => null
        };
    }
}
