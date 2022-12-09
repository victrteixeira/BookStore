namespace Auth.Core.Utils.Exceptions;

public class RequestException : Exception
{
    public RequestException(string message) : base(message)
    {
    }
}