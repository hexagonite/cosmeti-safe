using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmetiSafe.Data.Configurations;

public class IngredientConcernConfiguration : IEntityTypeConfiguration<IngredientConcern>
{
    public void Configure(EntityTypeBuilder<IngredientConcern> builder)
    {
        builder
            .HasKey(table => new
            {
                table.IngredientId,
                table.ConcernId
            });
    }
}