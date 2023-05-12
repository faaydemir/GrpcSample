using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

public static class ExceptionHandlerExtension
{
    public static IApplicationBuilder AddExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                var errorResponseBuilder = app.ApplicationServices.GetService<IErrorResponseBuilder>();

                var error = errorResponseBuilder != null
                ? errorResponseBuilder.FromException(exception)
                : ErrorResponse.Default;

                context.Response.StatusCode = (int)error.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(error));
            });
        });
        return app;
    }
}