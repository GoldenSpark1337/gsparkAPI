namespace gspark.Service.Common.Exceptions;

public class ApiException : ApiResponse
{
    public ApiException(int statusCode, string message = null, string innerException = null) : base(statusCode, message)
    {
        InnerException = innerException;
    }

    public string InnerException { get; set; }
}