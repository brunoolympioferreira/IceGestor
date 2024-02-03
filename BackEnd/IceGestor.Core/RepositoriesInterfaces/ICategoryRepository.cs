using IceGestor.Core.Entities;

namespace IceGestor.Core.RepositoriesInterfaces;
public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task Delete(int id);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
}
