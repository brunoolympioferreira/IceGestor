using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.CrossCutting.Exceptions;
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

    public async Task Delete(int id)
    {
        Category category = await _context.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id) ??
            throw new ValidationErrorsException("O id especificado não existe");
            
        _context.Categories.Remove(category);
    }

    public Task<List<Category>> GetAllAsync()
    {
        return _context.Categories.AsNoTracking().ToListAsync();
    }

    public Task<Category> GetByIdAsync(int id)
    {
        return _context.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id) ??
            throw new ValidationErrorsException("O id especificado não existe");
    }
}
