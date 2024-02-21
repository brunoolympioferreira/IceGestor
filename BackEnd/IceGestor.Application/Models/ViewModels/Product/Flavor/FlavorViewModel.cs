using IceGestor.Core.Entities;

namespace IceGestor.Application.Models.ViewModels.Product.Flavor;
public class FlavorViewModel
{
    public FlavorViewModel(Core.Entities.Flavor flavor)
    {
        Id = flavor.Id;
        Name = flavor.Name;
        Description = flavor.Description;
    }

    public FlavorViewModel()
    {
        
    }

    public int Id { get;}
    public string Name { get; }
    public string Description { get; }
}
