namespace IceGestor.Core.Entities;
public class ProductStock : BaseEntity
{
    public ProductStock(int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;

        CreatedAt = DateTime.Now;
    }

    public int ProductId { get; set; }
    public int Quantity { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; set; }

    public virtual Product Product { get; set; }
}
