using IceGestor.Core.Entities;

namespace IceGestor.Core.RepositoriesInterfaces;
public interface IFlavorRepository
{
    Task Add(Flavor flavor);
    void Update(Flavor flavor);
    Task Delete(int id);

    Task<Flavor> GetFlavorById(int id);
    Task<List<Flavor>> GetAll();
}
