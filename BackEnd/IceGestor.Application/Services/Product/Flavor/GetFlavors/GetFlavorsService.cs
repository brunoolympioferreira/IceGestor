using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Models.ViewModels.Product.Flavor;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.Product.Flavor.GetFlavors;
public class GetFlavorsService : IGetFlavorsService
{
    private readonly IUnityOfWork _unityOfWork;

    public GetFlavorsService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task<BaseResult<List<FlavorViewModel>>> GetAll()
    {
        var flavors = await _unityOfWork.Flavors.GetAll();

        var viewModels = flavors.Select(f => new FlavorViewModel(f)).ToList();

        return new BaseResult<List<FlavorViewModel>>(viewModels);

    }

    public Task<BaseResult<FlavorViewModel>> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
