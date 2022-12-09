using System.Net;
using System.Text.Json;
using Auth.API.Utils;
using Auth.Core.Utils.Exceptions;

namespace Auth.API.Middleware;

public class ExceptionHandlerMiddleware
{
    public readonly RequestDelegate Next;
    public readonly ILogger<ExceptionHandlerMiddleware> Logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        Next = next;
        Logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await Next(httpContext);
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
            case AuthException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case RequestException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            case PasswordException:
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                break;
            case RoleException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }
        
        Logger.LogError($"{error.GetType()}: {error.Message}\n{error.StackTrace}");
        var result = JsonSerializer.Serialize(responseModel);
        await context.Response.WriteAsync(result);
    }
}