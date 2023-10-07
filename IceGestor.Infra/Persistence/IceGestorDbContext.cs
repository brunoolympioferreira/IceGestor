using IceGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IceGestor.Infra.Persistence;
public class IceGestorDbContext : DbContext
{
    public IceGestorDbContext(DbContextOptions<IceGestorDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
