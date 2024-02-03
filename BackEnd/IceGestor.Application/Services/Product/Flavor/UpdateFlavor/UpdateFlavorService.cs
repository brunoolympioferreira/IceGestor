using IceGestor.Application.Models.InputModels.Product;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.Product.Flavor.UpdateFlavor;
public class UpdateFlavorService : IUpdateFlavorService
{
    private readonly IUnityOfWork _unityOfWork;
    public UpdateFlavorService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }
    public async Task Update(int id, FlavorInputModel model)
    {
        Validate(model);

        Core.Entities.Flavor flavor = await _unityOfWork.Flavors.GetFlavorById(id);

        flavor.Update(model.Name, model.Description);

        _unityOfWork.Flavors.Update(flavor);

        await _unityOfWork.CompleteAsync();
    }

    private static void Validate(FlavorInputModel model) 
    {
        var validator = new UpdateFlavorValidator();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
