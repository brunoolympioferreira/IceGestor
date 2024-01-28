using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;

namespace IceGestor.Infra.Persistence.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly IceGestorDbContext _context;
    public CategoryRepository(IceGestorDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }
}
