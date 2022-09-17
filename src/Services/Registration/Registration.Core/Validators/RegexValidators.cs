using System.Text.RegularExpressions;

namespace Registration.Core.Validators;

public static class RegexValidators
{
    public static bool NameIsValid(string name)
    {
        return Regex.IsMatch(name, @"^[0-9a-zA-Z']{3,50}$"); // TODO > Need to allow *'* character in this regex.
    }

    public static bool EmailIsValid(string email)
    {
        return Regex.IsMatch(email, @"[a-z A-z 0-9_\-]+[@]+[a-z]+[\.][a-z]{3,4}$");
    }
}