using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmetiSafe.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(p => p.MedianIngredientScore)
            .HasColumnType("decimal(2,1)");

        builder
            .Property(p => p.AverageIngredientScore)
            .HasColumnType("decimal(2,1)");
    }
}