using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmetiSafe.Data.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder
            .HasIndex(s => s.Name)
            .IsUnique();
    }
}