namespace CosmetiSafe.Domain.Models;

public class Concern : IdentifiableEntity
{
    public string Name { get; set; }
    public virtual IEnumerable<IngredientConcern> IngredientConcerns { get; set; }
}