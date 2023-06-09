﻿using System.Net;

public class ErrorResponseBuilder : IErrorResponseBuilder
{
    public ErrorResponse FromException(Exception ex)
    {
        var httpStatusCode = HttpStatusCode.InternalServerError;

        if (ex is ApiException apiException) httpStatusCode = apiException.StatusCode;

        return new ErrorResponse(ex?.Message ?? "Something went wrong.", httpStatusCode);
    }
}