using System.Net;
using System.Text.Json;
using Catalog.Application.Exceptions;
using Catalog.Core.Exceptions;

namespace Catalog.API.ExceptionMiddleware;

public class ExceptionHandlingMiddleware
{
    public readonly RequestDelegate _next;
    public readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception error)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        var responseModel = ApiResponse<string>.Fail(error.Message);

        switch (error)
        {
            case DomainException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case RequestException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case QueryException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }
        
        _logger.LogError($"{error.GetType()}: {error.Message}\n{error.StackTrace}");
        var result = JsonSerializer.Serialize(responseModel);
        await context.Response.WriteAsync(result);
    }

}