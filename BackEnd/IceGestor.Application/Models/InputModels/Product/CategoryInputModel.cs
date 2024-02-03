using IceGestor.Core.Entities;

namespace IceGestor.Application.Models.InputModels.Product;
public class CategoryInputModel
{
    public string Name { get; set; }

    public Category ToEntity() => new(Name);
}
