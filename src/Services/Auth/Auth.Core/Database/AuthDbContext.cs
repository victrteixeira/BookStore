using Auth.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Core.Database;

public class AuthDbContext : IdentityDbContext<AppUser>
{
    public AuthDbContext()
    {
    }

    public AuthDbContext(DbContextOptions<AuthDbContext> opt) : base(opt)
    {
    }
}