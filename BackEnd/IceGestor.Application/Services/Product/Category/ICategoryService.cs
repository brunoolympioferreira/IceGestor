using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;

namespace IceGestor.Application.Services.Product.Category;
public interface ICategoryService
{
    Task<BaseResult<int>> Create(CategoryInputModel model);
}
