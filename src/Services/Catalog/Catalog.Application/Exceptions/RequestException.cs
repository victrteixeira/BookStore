namespace Catalog.Application.Exceptions;

public class RequestException : Exception
{
    public RequestException()
    {
    }

    public RequestException(string message) : base(message)
    {
    }
}