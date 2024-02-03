using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.Product.Flavor.CreateFlavor;
public class CreateFlavorService : ICreateFlavorService
{
    private readonly IUnityOfWork _unityOfWork;
    public CreateFlavorService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }
    public async Task<BaseResult> Execute(FlavorInputModel request)
    {
        Validate(request);

        Core.Entities.Flavor flavor = request.ToEntity();

        await _unityOfWork.BeginTransactionAsync();

        await _unityOfWork.Flavors.Add(flavor);

        await _unityOfWork.CompleteAsync();

        await _unityOfWork.CommitAsync();

        return new BaseResult();
    }

    private static void Validate(FlavorInputModel request)
    {
        var validator = new CreateFlavorValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
