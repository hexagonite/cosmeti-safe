namespace CosmetiSafe.Domain.Models;

public class IngredientConcern : Entity
{
    public Ulid IngredientId { get; set; }
    public Ulid ConcernId { get; set; }
    public Ingredient Ingredient { get; set; }
    public Concern Concern { get; set; }
    public ConcernSeverity ConcernSeverity { get; set; }
}