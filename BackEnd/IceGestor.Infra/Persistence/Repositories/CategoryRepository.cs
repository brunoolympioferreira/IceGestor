using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

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

    public Task<List<Category>> GetAllAsync()
    {
        return _context.Categories.AsNoTracking().ToListAsync();
    }
}
