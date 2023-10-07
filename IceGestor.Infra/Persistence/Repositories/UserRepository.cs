using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;

namespace IceGestor.Infra.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IceGestorDbContext _dbContext;
    public UserRepository(IceGestorDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}
