using System.Net;

public class ErrorResponseBuilder : IErrorResponseBuilder
{
    public ErrorResponse FromException(Exception ex)
    {
        var httpStatusCode = HttpStatusCode.InternalServerError;

        if (ex is PriceCantBeNegativeException) httpStatusCode = HttpStatusCode.BadRequest;
        else if (ex is ProductNotFoundException) httpStatusCode = HttpStatusCode.NotFound;

        return new ErrorResponse(ex?.Message ?? "Something went wrong.", httpStatusCode);
    }
}