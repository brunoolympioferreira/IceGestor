using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IceGestor.Infra.Persistence.Repositories;
public class FlavorRepository : IFlavorRepository
{
    private readonly IceGestorDbContext _dbContext;
    public FlavorRepository(IceGestorDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Flavor flavor)
    {
        await _dbContext.Flavors.AddAsync(flavor);
    }

    public void Update(Flavor flavor)
    {
        _dbContext.Flavors.Update(flavor);
    }

    public async Task Delete(int id)
    {
        Flavor flavor = await _dbContext.Flavors.SingleOrDefaultAsync(f => f.Id == id);

        _dbContext.Flavors.Remove(flavor);

    }

    public Task<List<Flavor>> GetAll()
    {
        return _dbContext.Flavors.AsNoTracking().ToListAsync();
    }

    public Task<Flavor> GetFlavorById(int id)
    {
        return _dbContext.Flavors.AsNoTracking().SingleOrDefaultAsync(f => f.Id == id);
    }
}
