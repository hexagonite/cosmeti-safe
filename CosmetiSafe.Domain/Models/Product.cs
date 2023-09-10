using System.ComponentModel.DataAnnotations.Schema;

namespace CosmetiSafe.Domain.Models;

public class Product : IdentifiableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Ulid CategoryId { get; set; }
    public Category Category { get; set; }
    public int WorstIngredientScore { get; set; }
    public decimal MedianIngredientScore { get; set; }
    public decimal AverageIngredientScore { get; set; }
    public MarketedFor MarketedFor { get; set; }
    public virtual IEnumerable<StoreProduct> StoreProducts { get; set; }
    public virtual IEnumerable<ProductIngredient> ProductIngredients { get; set; }
}