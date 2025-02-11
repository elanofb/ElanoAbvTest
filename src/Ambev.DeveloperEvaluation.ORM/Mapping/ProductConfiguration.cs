using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);

        //NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(builder.Property<int>("Id"));

        builder.Property(u => u.Id).IsRequired();
        builder.Property(u => u.Description).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.IsAvailable);
        builder.Property(u => u.UnitPrice);

    }
}
