using IceGestor.Application.Models.ViewModels;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.Product.Flavor.DeleteFlavor;
public class DeleteFlavorService : IDeleteFlavorService
{
    private readonly IUnityOfWork _unityOfWork;

    public DeleteFlavorService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task<BaseResult> Delete(int id)
    {
        await _unityOfWork.Flavors.Delete(id);

        return new BaseResult();
    }
}
