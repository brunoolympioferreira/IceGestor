namespace IceGestor.Application.Models.InputModels.Product;
public class ProductInputModel
{
    public decimal Amount { get; set; }
    public int FlavorId { get; set; }
    public int CategoryId { get; set; }

    public Core.Entities.Product ToEntity() => new(Amount, FlavorId, CategoryId);
}
