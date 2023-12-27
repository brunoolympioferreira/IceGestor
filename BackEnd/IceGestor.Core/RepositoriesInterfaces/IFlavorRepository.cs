using IceGestor.Core.Entities;

namespace IceGestor.Core.RepositoriesInterfaces;
public interface IFlavorRepository
{
    Task Add(Flavor flavor);
    void Update(Flavor flavor);

    Task<Flavor> GetFlavorById(int id);
    IEnumerable<Flavor> GetAll();
}
