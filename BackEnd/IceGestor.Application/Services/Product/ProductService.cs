using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Models.ViewModels.Product;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.Product;
public class ProductService : IProductService
{
    private readonly IUnityOfWork _unityOfWork;
    public ProductService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }
    public async Task<BaseResult<int>> Create(ProductInputModel model)
    {
        ValidateModel(model);

        var validationResult = ValidateExistenceForeignKeys(model);

        if (validationResult.Success == false)
        {
            return new BaseResult<int>(0, false, validationResult.Message);
        }

        var product = model.ToEntity();

        await _unityOfWork.Products.AddAsync(product);
        await _unityOfWork.CompleteAsync();

        return new BaseResult<int>(product.Id);
    }

    public async Task<BaseResult<List<ProductViewModel>>> GetAll()
    {
        var products = await _unityOfWork.Products.GetAllAsync();

        var viewModels = products.Select(p => new ProductViewModel(p)).ToList();

        return new BaseResult<List<ProductViewModel>>(viewModels);
    }

    public async Task<BaseResult<ProductViewModel>> GetById(int id)
    {
        var product = await _unityOfWork.Products.GetByIdAsync(id) ??
            throw new ValidationErrorsException("O id especificado não existe!");

        var viewModel = new ProductViewModel(product);

        return new BaseResult<ProductViewModel>(viewModel);
    }

    private static void ValidateModel(ProductInputModel model)
    {
        var validator = new ProductValidator();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }

    private BaseResult ValidateExistenceForeignKeys(ProductInputModel model)
    {
        var flavor = _unityOfWork.Flavors.GetFlavorById(model.FlavorId);
        var category = _unityOfWork.Categories.GetByIdAsync(model.CategoryId);
        if (flavor == null)
            return new BaseResult(false, "Esse sabor não existe em nosso banco de dados");
        else if (category == null)
            return new BaseResult(false, "Essa categoria não existe em nosso banco de dados");
        else return new BaseResult();
    }
}
