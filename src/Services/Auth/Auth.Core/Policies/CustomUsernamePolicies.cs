using Auth.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Policies;

public class CustomUserPolicies : UserValidator<AppUser>
{
    public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
    {
        IdentityResult result = await base.ValidateAsync(manager, user);
        List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

        var emailMatch = Array.Exists(EmailHosters, domain => user.Email.ToLower().EndsWith(domain));
        if (!emailMatch)
        {
            errors.Add(new IdentityError { Description = "This email domain isn't allowed"});
        }

        return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        // TODO > Logger isn't returning a proper message
    }

    private string[] EmailHosters { get; } =
    {
        "@gmail.com",
        "@yahoo.com",
        "@hotmail.com",
        "@aol.com",
        "@msn.com",
        "@live.com",
        "@outlook.com",
        "@uol.com.br"
    };
}