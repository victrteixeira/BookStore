namespace Auth.Core.Utils.Exceptions;

public class PasswordException : Exception
{
    public PasswordException(string message) : base(message)
    {
    }
}