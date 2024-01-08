using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;

namespace IceGestor.Application.Services.Product.Flavor.CreateFlavor;
public interface ICreateFlavorService
{
    Task<BaseResult> Execute(CreateFlavorInputModel request);
}
