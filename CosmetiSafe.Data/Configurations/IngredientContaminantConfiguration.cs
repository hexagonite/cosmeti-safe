using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CosmetiSafe.Data.Configurations;

public class IngredientContaminantConfiguration : IEntityTypeConfiguration<IngredientContaminant>
{
    public void Configure(EntityTypeBuilder<IngredientContaminant> builder)
    {
        builder
            .HasKey(table => new
            {
                table.IngredientId,
                table.ContaminantId
            });
        
        builder
            .HasOne(pt => pt.Contaminant)
            .WithMany(p => p.ContaminantOf)
            .HasForeignKey(pt => pt.ContaminantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(pt => pt.Ingredient)
            .WithMany(t => t.Contaminants)
            .HasForeignKey(pt => pt.IngredientId);
    }
}