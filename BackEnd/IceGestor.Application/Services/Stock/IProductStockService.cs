using IceGestor.Application.Models.InputModels.Stock;
using IceGestor.Application.Models.ViewModels;

namespace IceGestor.Application.Services.Stock;
public interface IProductStockService
{
    Task<BaseResult<int>> Create(ProductStockInputModel model);
}
