using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmetiSafe.Data;

public interface ICosmetiSafeContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Concern> Concerns { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientConcern> IngredientConcerns { get; set; }
    public DbSet<IngredientContaminant> IngredientContaminants { get; set; }
    public DbSet<IngredientSynonym> IngredientSynonyms { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductIngredient> ProductIngredients { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreProduct> StoreProducts { get; set; }
}