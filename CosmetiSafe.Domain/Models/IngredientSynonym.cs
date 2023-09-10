namespace CosmetiSafe.Domain.Models;

public class IngredientSynonym : IdentifiableEntity
{
    public string Name { get; set; }
    public Ulid IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}