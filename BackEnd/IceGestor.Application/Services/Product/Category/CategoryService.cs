using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Models.ViewModels.Product.Category;
using IceGestor.Core.Entities;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.Product.Category;
public class CategoryService : ICategoryService
{
    private readonly IUnityOfWork _unityOfWork;
    public CategoryService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }
    public async Task<BaseResult<int>> Create(CategoryInputModel request)
    {
        Validate(request);

        Core.Entities.Category category = request.ToEntity();

        await _unityOfWork.Categories.AddAsync(category);

        await _unityOfWork.CompleteAsync();

        return new BaseResult<int>(category.Id);
    }

    public async Task<BaseResult<List<CategoryViewModel>>> GetAll()
    {
        var categories = await _unityOfWork.Categories.GetAllAsync();

        var viewModels = categories.Select(c => new CategoryViewModel(c)).ToList();

        return new BaseResult<List<CategoryViewModel>>(viewModels);
    }

    public async Task<BaseResult<CategoryViewModel>> GetById(int id)
    {
        var category = await _unityOfWork.Categories.GetByIdAsync(id) ?? throw new ValidationErrorsException("O id espeficicado não existe");

        var viewModel = new CategoryViewModel(category);

        return new BaseResult<CategoryViewModel>(viewModel);
    }

    private static void Validate(CategoryInputModel request) 
    {
        var validator = new CategoryValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
