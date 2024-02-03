using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Models.ViewModels.Product.Flavor;

namespace IceGestor.Application.Services.Product.Flavor.GetFlavors;
public interface IGetFlavorsService
{
    Task<BaseResult<List<FlavorViewModel>>> GetAll();
    Task<BaseResult<FlavorViewModel>> GetById(int id);
}
