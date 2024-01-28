using IceGestor.Application.Models.ViewModels;

namespace IceGestor.Application.Services.Product.Flavor.DeleteFlavor;
public interface IDeleteFlavorService
{
    Task<BaseResult> Delete(int id);
}
