using CosmetiSafe.Domain.Models.Enums;

namespace CosmetiSafe.Domain.Models;

public class Ingredient : IdentifiableEntity
{
    public string PrimaryName { get; set; }
    public int HazardScore { get; set; }
    public int MinimumHazardScore { get; set; }
    public DataAvailability DataAvailability { get; set; }
    public string DependsOnUsageDescription { get; set; }
    public string Source { get; set; }
    public virtual IEnumerable<ProductIngredient> ProductIngredients { get; set; }
    public virtual IEnumerable<IngredientConcern> IngredientConcerns { get; set; }
    public virtual IEnumerable<IngredientContaminant> Contaminants { get; set; }
    public virtual IEnumerable<IngredientContaminant> ContaminantOf { get; set; }
}