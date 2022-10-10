namespace Catalog.Core.Exceptions;

public class DomainException : Exception
{
    public DomainException() : base()
    {
    }

    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(string? message, Exception? inner) : base(message, inner)
    {
    }

    public DomainException(string? message, string? paramName) : base(message)
    {
    }

    public static void When(bool hasError, string errorMessage)
    {
        if (hasError)
            throw new DomainException(errorMessage);
    }
}