using System.Net;

public class ErrorResponse
{
    public HttpStatusCode StatusCode { get; }
    public string Message { get; }

    public ErrorResponse(string message, HttpStatusCode statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }

    public static ErrorResponse Default
    {
        get => new ErrorResponse("Something went wrong.", HttpStatusCode.InternalServerError);
    }
}