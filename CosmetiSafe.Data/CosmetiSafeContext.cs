using CosmetiSafe.Data.ValueConverters;
using CosmetiSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmetiSafe.Data;

public class CosmetiSafeContext : DbContext, ICosmetiSafeContext
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
    
    public CosmetiSafeContext(DbContextOptions<CosmetiSafeContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options =>
        {
            options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            options.MigrationsAssembly("CosmetiSafe.Migrations");
        });
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CosmetiSafeContext).Assembly);
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Ulid>()
            .HaveConversion<UlidToStringConverter>()
            .HaveConversion<UlidToBytesConverter>();
    }
}