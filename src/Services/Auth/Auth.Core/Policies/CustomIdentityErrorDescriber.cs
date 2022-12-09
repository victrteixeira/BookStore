using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Policies;

public sealed class CustomIdentityErrorDescriber : IdentityErrorDescriber
{
    public IdentityError EmailDomainNotAllowed() { return new IdentityError { Code = nameof(EmailDomainNotAllowed), Description = "Email domain provided isn't allowed." }; }
    public IdentityError PasswordAsUsername() { return new IdentityError { Code = nameof(PasswordAsUsername), Description = "You cannot use your username as your password." }; }
    public IdentityError CommonPasswordSequence() { return new IdentityError { Code = nameof(CommonPasswordSequence), Description = "That is a common password sequence and is too insecure." }; }
    public IdentityError AgeNotTrusted() { return new IdentityError { Code = nameof(AgeNotTrusted), Description = "Registered age could not be trusted." }; }
}