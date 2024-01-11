using IceGestor.Core.Entities;

namespace IceGestor.Application.Models.InputModels.Product;
public class FlavorInputModel
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Flavor ToEntity() => new(Name, Description);
}
