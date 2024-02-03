namespace IceGestor.Application.Models.ViewModels.Product.Category;
public class CategoryViewModel
{
    public CategoryViewModel(Core.Entities.Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }

    public CategoryViewModel() { }

    public int Id { get; }
    public string Name { get; }
}
