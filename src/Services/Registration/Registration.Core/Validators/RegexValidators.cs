using System.Text.RegularExpressions;

namespace Registration.Core.Validators;

public static class RegexValidators
{
    public static bool NameIsValid(string name)
    {
        return Regex.IsMatch(name, @"^[a-zA-Z]+([a-zA-Z]+( [a-zA-Z]+)+) $");
    }

    public static bool UsernameIsValid(string username)
    {
        return Regex.IsMatch(username, @"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$");
    }

    public static bool EmailIsValid(string email)
    {
        return Regex.IsMatch(email, @"[a-z A-z 0-9_\-]+[@]+[a-z]+[\.][a-z]{3,4}$");
    }
}