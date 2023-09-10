using System.ComponentModel.DataAnnotations;

namespace CosmetiSafe.Domain;

public abstract class IdentifiableEntity : Entity
{
    [Key]
    public Ulid Id { get; init; }
}