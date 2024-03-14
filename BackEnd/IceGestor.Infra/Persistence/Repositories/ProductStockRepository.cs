using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;

namespace IceGestor.Infra.Persistence.Repositories;
public class ProductStockRepository : IProductStockRepository
{
    private readonly IceGestorDbContext _context;
    public ProductStockRepository(IceGestorDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(ProductStock productStock)
    {
        await _context.AddAsync(productStock);
    }
}
