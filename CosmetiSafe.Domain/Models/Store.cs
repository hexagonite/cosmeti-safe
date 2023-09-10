namespace CosmetiSafe.Domain.Models;

public class Store : IdentifiableEntity
{
    public string Name { get; set; }
    public virtual IEnumerable<StoreProduct> StoreProducts { get; set; }
}