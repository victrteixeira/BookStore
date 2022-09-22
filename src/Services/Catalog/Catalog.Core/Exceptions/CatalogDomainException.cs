namespace Catalog.Core.Exceptions;

public class CatalogDomainException : Exception
{
    public CatalogDomainException() : base()
    {
    }

    public CatalogDomainException(string? message) : base(message)
    {
    }

    public CatalogDomainException(string? message, Exception? inner) : base(message, inner)
    {
    }

    public CatalogDomainException(string? message, string? paramName) : base(message)
    {
    }

    public static void When(bool hasError, string errorMessage)
    {
        if (hasError)
            throw new CatalogDomainException(errorMessage);
    }
}