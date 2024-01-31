using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
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
