using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmetiSafe.Data.Configurations;

public class ProductIngredientConfiguration : IEntityTypeConfiguration<ProductIngredient>
{
    public void Configure(EntityTypeBuilder<ProductIngredient> builder)
    {
        builder
            .HasKey(table => new
            {
                table.ProductId,
                table.IngredientId
            });
    }
}
