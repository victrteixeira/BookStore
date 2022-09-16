namespace Registration.Core.Validators;

public static class UsernameValidator
{
    private static string _bannedChar = "*\"()[];@!`\\/#$%^&+|<:{>}=";
    
    public static void UsernameIsValid(string username)
    {
        DomainException.When(username.Length > 50, "Username is too long.");
        DomainException.When(username.Length < 4, "Username is too short.");
        if (username.Any(ch => _bannedChar.Contains(ch)))
            throw new DomainException("Username has not allowed char.", nameof(username));
        
    }
}