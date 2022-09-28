using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infra.Database.TablesConfiguration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(p => p.GenreId);
        
        builder.Property(p => p.GenreId)
            .UseIdentityColumn()
            .HasColumnName("Genre_Id")
            .HasColumnOrder(0);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("Genre_Name")
            .HasMaxLength(60)
            .HasColumnOrder(1);

        builder.Property(p => p.SubGenre)
            .HasColumnName("SubGenre")
            .HasMaxLength(60)
            .HasColumnOrder(2);
        
        builder.Property(p => p.BriefDescription)
            .HasColumnName("Brief_Description")
            .HasMaxLength(100)
            .HasColumnOrder(4);
    }
}