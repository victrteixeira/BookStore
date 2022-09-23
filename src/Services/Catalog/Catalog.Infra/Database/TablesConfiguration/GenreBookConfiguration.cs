using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infra.Database.TablesConfiguration;

public class GenreBookConfiguration : IEntityTypeConfiguration<GenreBook>
{
    public void Configure(EntityTypeBuilder<GenreBook> builder)
    {
        builder.HasKey(bc => new { bc.BookId, bc.GenreId });

        builder.HasOne(x => x.Book)
            .WithMany(y => y.Genres)
            .HasForeignKey(fk => fk.BookId);

        builder.HasOne(x => x.Genre)
            .WithMany(y => y.Books)
            .HasForeignKey(fk => fk.GenreId);
    }
}