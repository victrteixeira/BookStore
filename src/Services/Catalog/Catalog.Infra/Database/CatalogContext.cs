using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infra.Database;

public class CatalogContext : DbContext
{
    public CatalogContext()
    {
    }

    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }
    
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }
}