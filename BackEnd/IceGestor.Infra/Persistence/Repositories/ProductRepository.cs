using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IceGestor.Infra.Persistence.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly IceGestorDbContext _context;
    public ProductRepository(IceGestorDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        _context.Update(product);
    }

    public Task<List<Product>> GetAllAsync()
    {
        return _context.Products
            .AsNoTracking()
            .Include(p => p.Flavor)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        return _context.Products
            .AsNoTracking()
            .Include(p => p.Flavor)
            .Include(p => p.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
}
