using IceGestor.Core.Entities;

namespace IceGestor.Core.RepositoriesInterfaces;
public interface IProductStockRepository
{
    Task AddAsync(ProductStock productStock);
}
