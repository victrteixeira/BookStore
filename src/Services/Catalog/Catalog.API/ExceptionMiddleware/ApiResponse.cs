namespace Catalog.API.ExceptionMiddleware;

public class ApiResponse<T>
{
    public dynamic? Data { get; set; }
    public bool Succeeded { get; set; }
    public string? Message { get; set; }

    public static ApiResponse<T> Fail(string errorMessage) => new ApiResponse<T> { Succeeded = false, Message = errorMessage };
    
    public static ApiResponse<T> Success(dynamic data, string successMessage) => new ApiResponse<T> { Succeeded = true, Message = successMessage, Data = data };
}