using IceGestor.Application.Models.InputModels.Stock;
using IceGestor.Application.Models.ViewModels;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.Stock;
public class ProductStockService : IProductStockService
{
    private readonly IUnityOfWork _unityOfWork;
    public ProductStockService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }
    public async Task<BaseResult<int>> Create(ProductStockInputModel model)
    {
        ValidateModel(model);

        var product = await _unityOfWork.Products.GetByIdAsync(model.ProductId);

        if (product is null) return new BaseResult<int>(0, false, "Produto não existe no banco de dados");

        Core.Entities.ProductStock productStock = model.ToEntity();

        await _unityOfWork.ProductStocks.AddAsync(productStock);
        await _unityOfWork.CompleteAsync();

        return new BaseResult<int>(productStock.Id);
    }

    private static void ValidateModel(ProductStockInputModel model)
    {
        var validator = new ProductStockValidator();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
