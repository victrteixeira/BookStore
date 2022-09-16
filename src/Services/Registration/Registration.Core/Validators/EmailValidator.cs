namespace Registration.Core.Validators;

public static class EmailValidator
{
    public static void EmailIsValid(string email)
    {
        DomainException.When(email.Length > 100, "Email is too long.");
        DomainException.When(email.Length < 10, "Email is too short.");
        DomainException.When(!RegexValidators.EmailIsValid(email), "Email is invalid.");
    }
}