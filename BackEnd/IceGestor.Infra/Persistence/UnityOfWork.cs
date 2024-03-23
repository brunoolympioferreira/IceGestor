using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.CrossCutting.Exceptions;
using Microsoft.EntityFrameworkCore.Storage;

namespace IceGestor.Infra.Persistence;
public class UnityOfWork : IUnityOfWork
{
    private IDbContextTransaction _transaction;
    private readonly IceGestorDbContext _context;
    public UnityOfWork(
        IceGestorDbContext context,
        IUserRepository users,
        IFlavorRepository flavors,
        ICategoryRepository categories,
        IProductRepository products,
        IProductStockRepository stock)
    {
        _context = context;
        Users = users;
        Flavors = flavors;
        Categories = categories;
        Products = products;
        ProductStocks = stock;
    }
    public IUserRepository Users { get; }

    public IFlavorRepository Flavors { get; }
    public ICategoryRepository Categories { get; }
    public IProductRepository Products { get; }
    public IProductStockRepository ProductStocks { get; }


    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (IceGestorException ex)
        {
            await _transaction.RollbackAsync();
            throw new IceGestorException(ex.ToString());
        }
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
