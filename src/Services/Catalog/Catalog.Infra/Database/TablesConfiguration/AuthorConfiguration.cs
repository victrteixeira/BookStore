using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infra.Database.TablesConfiguration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(pk => pk.AuthorId);

        builder.Property(p => p.AuthorId)
            .UseIdentityColumn()
            .HasColumnName("Author_Id")
            .HasColumnOrder(0);

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("First_Name")
            .HasColumnOrder(1);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("Last_Name")
            .HasColumnOrder(2);

        builder.Property(p => p.BornAt)
            .IsRequired()
            .HasMaxLength(6)
            .HasColumnName("Born_At")
            .HasColumnOrder(3);

        builder.Property(p => p.DiedAt)
            .IsRequired()
            .HasMaxLength(6)
            .HasColumnName("Died_At")
            .HasColumnOrder(4);

        builder.Property(p => p.Country)
            .HasMaxLength(60)
            .HasColumnName("Country")
            .HasColumnOrder(5);

        builder.Property(p => p.BriefDescription)
            .HasMaxLength(100)
            .HasColumnName("Brief_Description")
            .HasColumnOrder(6);

        builder.HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(fk => fk.AuthorId);
    }
}