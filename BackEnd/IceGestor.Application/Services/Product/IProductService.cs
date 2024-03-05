using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Models.ViewModels.Product;

namespace IceGestor.Application.Services.Product;
public interface IProductService
{
    Task<BaseResult<int>> Create(ProductInputModel model);
    Task<BaseResult> Update(int id, ProductInputModel model);
    Task<BaseResult> Delete(int id);
    Task<BaseResult<List<ProductViewModel>>> GetAll();
    Task<BaseResult<ProductViewModel>> GetById(int id);
}
