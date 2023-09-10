namespace CosmetiSafe.Domain.Models;

public class StoreProduct : Entity
{
    public Ulid ProductId { get; set; }
    public Ulid StoreId { get; set; }
    public Product Product { get; set; }
    public Store Store { get; set; }
    public decimal Price { get; set; }
    public Currency Currency { get; set; }
    public string ProductUrl { get; set; }
}