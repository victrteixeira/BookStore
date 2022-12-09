namespace Auth.Core.Utils.Exceptions;

public class AuthException : Exception
{
    public AuthException(string message) : base(message)
    {
    }
}