using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infra.Database.TablesConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(p => p.BookId);

        builder.Property(p => p.BookId)
            .UseIdentityColumn()
            .HasColumnName("Book_Id")
            .HasColumnOrder(0);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("Book_Name")
            .HasColumnOrder(1);

        builder.Property(p => p.Pages)
            .IsRequired()
            .HasColumnName("Pages")
            .HasColumnOrder(2);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(6, 2)
            .HasColumnName("Price")
            .HasColumnOrder(3);

        builder.Property(p => p.Language)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("Language")
            .HasColumnOrder(4);

        builder.Property(p => p.Publisher)
            .HasMaxLength(50)
            .HasColumnName("Publisher")
            .HasColumnOrder(5);

        builder.HasOne(a => a.Genre)
            .WithMany(b => b.Books)
            .HasForeignKey(fr => fr.GenreId);
    }
}