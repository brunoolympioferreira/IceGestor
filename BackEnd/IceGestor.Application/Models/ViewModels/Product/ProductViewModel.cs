namespace IceGestor.Application.Models.ViewModels.Product;
public class ProductViewModel
{
    public ProductViewModel(Core.Entities.Product product)
    {
        Id = product.Id;
        Amount = product.Amount;
        FlavorName = product.Flavor.Name;
        FlavorDescription = product.Flavor.Description;
        CategoryName = product.Category.Name;
    }
    public int Id { get; }
    public decimal Amount { get; }
    public string FlavorName { get; }
    public string FlavorDescription { get; }
    public string CategoryName { get; }
}
