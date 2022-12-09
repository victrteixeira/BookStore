using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Utils.Messages;

public static class IdentityMessage
{
    public static string IdentityMessageBuilder(params IEnumerable<IdentityError>[] errors)
    {
        var builder = new StringBuilder();
        foreach (var error in errors)
        {
            foreach (var identityError in error)
                builder.AppendJoin(";", identityError.Description);
        }
        
        return builder.ToString();
    }
}