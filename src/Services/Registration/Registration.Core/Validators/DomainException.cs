namespace Registration.Core.Validators;

public class DomainException : Exception
{
    public DomainException() : base()
    {
    }
    public DomainException(string error) : base(error)
    {
    }

    public DomainException(string error, Exception inner) : base(error, inner)
    {
    }
    
    public DomainException(string error, string paramName) : base(error)
    {
    }

    public static void When(bool hasError, string error)
    {
        if (hasError)
            throw new DomainException(error);
    }
}