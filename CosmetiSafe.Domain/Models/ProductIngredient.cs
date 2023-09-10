namespace CosmetiSafe.Domain.Models;

public class ProductIngredient : Entity
{
    public Ulid ProductId { get; set; }
    public Ulid IngredientId { get; set; }
    public Product Product { get; set; }
    public Ingredient Ingredient { get; set; }
    public int Order { get; set; }
}