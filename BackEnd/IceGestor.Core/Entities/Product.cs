namespace IceGestor.Core.Entities;
public class Product : BaseEntity
{
    public Product(decimal amount, int flavorId, int categoryId)
    {
        Amount = amount;
        FlavorId = flavorId;
        CategoryId = categoryId;

        CreatedAt = DateTime.Now;
    }

    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int FlavorId { get; set; }
    public int CategoryId { get; set; }

    public virtual Flavor Flavor { get; set; }
    public virtual Category Category { get; set; }
}
