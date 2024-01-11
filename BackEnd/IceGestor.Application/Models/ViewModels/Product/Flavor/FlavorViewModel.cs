using IceGestor.Core.Entities;

namespace IceGestor.Application.Models.ViewModels.Product.Flavor;
public class FlavorViewModel
{
    public FlavorViewModel(Core.Entities.Flavor flavor)
    {
        Name = flavor.Name;
        Description = flavor.Description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
}
