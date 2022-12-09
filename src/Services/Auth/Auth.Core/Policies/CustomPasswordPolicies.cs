using Auth.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Policies;

public class CustomPasswordPolicies : PasswordValidator<AppUser>
{
    public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
    {
        IdentityResult result = await base.ValidateAsync(manager, user, password);
        List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

        if (string.Equals(user.UserName, password, StringComparison.OrdinalIgnoreCase))
        {
            errors.Add(new CustomIdentityErrorDescriber().PasswordAsUsername());
        }

        if (password.Contains("123456789"))
        {
            errors.Add(new CustomIdentityErrorDescriber().CommonPasswordSequence());
        }

        if (password.ToLower().Contains(user.FirstName.ToLower()) ||
            password.ToLower().Contains(user.LastName.ToLower()) ||
            password.ToLower().Contains(user.FirstName.ToLower() + user.LastName.ToLower()))
        {
            errors.Add(new CustomIdentityErrorDescriber().CommonPasswordSequence());
        }

        if (password.ToLower().Contains("password") || password.ToLower().Contains("qwerty"))
        {
            errors.Add(new CustomIdentityErrorDescriber().CommonPasswordSequence());
        }

        return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
    }
}