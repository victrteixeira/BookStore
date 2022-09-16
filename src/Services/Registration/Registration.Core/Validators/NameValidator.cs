namespace Registration.Core.Validators;

public static class NameValidator
{
    public static void FirstNameIsValid(string name)
    {
        DomainException.When(string.IsNullOrEmpty(name), "First Name can not to be empty.");
        DomainException.When(name.Length > 50, "First Name is too long.");
        DomainException.When(name.Length < 2, "First Name is too short.");
        DomainException.When(RegexValidators.NameIsValid(name), "First Name is invalid.");
    }

    public static void LastNameIsValid(string name)
    {
        DomainException.When(string.IsNullOrEmpty(name), "Last Name can not to be empty.");
        DomainException.When(name.Length > 50, "Last Name is too long.");
        DomainException.When(name.Length < 2, "Last Name is too short.");
        DomainException.When(RegexValidators.NameIsValid(name), "Last Name is invalid.");
    }
}