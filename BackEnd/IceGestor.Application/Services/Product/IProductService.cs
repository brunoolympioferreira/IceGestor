using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;

namespace IceGestor.Application.Services.Product;
public interface IProductService
{
    Task<BaseResult<int>> Create(ProductInputModel model);
}
