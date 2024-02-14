namespace IceGestor.Core.Entities;
public class Product : BaseEntity
{
    public Product(decimal amount, int idFlavor, int idCategory)
    {
        Amount = amount;
        IdFlavor = idFlavor;
        IdCategory = idCategory;

        CreatedAt = DateTime.Now;
    }

    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int IdFlavor { get; set; }
    public int IdCategory { get; set; }

    public virtual Flavor Flavor { get; set; }
    public virtual Category Category { get; set; }
}
