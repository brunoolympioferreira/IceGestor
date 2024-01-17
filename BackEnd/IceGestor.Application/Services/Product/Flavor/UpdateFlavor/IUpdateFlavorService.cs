using IceGestor.Application.Models.InputModels.Product;

namespace IceGestor.Application.Services.Product.Flavor.UpdateFlavor;
public interface IUpdateFlavorService
{
    Task Update(int id, FlavorInputModel model);
}
