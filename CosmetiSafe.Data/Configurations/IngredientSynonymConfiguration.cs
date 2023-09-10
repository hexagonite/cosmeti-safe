using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmetiSafe.Data.Configurations;

public class IngredientSynonymConfiguration : IEntityTypeConfiguration<IngredientSynonym>
{
    public void Configure(EntityTypeBuilder<IngredientSynonym> builder)
    {
        builder
            .HasIndex(i => i.Name)
            .IsUnique();
    }
}