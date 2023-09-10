using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmetiSafe.Data.Configurations;

public class StoreProductConfiguration : IEntityTypeConfiguration<StoreProduct>
{
    public void Configure(EntityTypeBuilder<StoreProduct> builder)
    {
        builder
            .HasKey(table => new
            {
                table.StoreId,
                table.ProductId
            });


        builder
            .Property(p => p.Price)
            .HasColumnType("decimal(9,2)");
    }
}