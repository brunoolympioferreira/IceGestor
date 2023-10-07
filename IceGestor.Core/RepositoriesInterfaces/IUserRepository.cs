using IceGestor.Core.Entities;

namespace IceGestor.Core.RepositoriesInterfaces;
public interface IUserRepository
{
    Task AddAsync(User user);
}
