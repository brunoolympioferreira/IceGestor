using IceGestor.Core.Entities;

namespace IceGestor.Core.RepositoriesInterfaces;
public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task<List<Category>> GetAllAsync();
}
