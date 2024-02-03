using IceGestor.Core.RepositoriesInterfaces;

namespace IceGestor.Infra.Persistence;
public interface IUnityOfWork
{
    IUserRepository Users { get; }
    IFlavorRepository Flavors { get; }
    ICategoryRepository Categories { get; }

    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
}
