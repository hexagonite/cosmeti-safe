namespace CosmetiSafe.Domain.Models;

public class IngredientContaminant : Entity
{
    public Ulid IngredientId { get; set; }
    public Ulid ContaminantId { get; set; }
    public Ingredient Ingredient { get; set; }
    public Ingredient Contaminant { get; set; }
}