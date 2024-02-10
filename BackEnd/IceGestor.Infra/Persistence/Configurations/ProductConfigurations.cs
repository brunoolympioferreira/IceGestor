using IceGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IceGestor.Infra.Persistence.Configurations;
public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount).IsRequired();

        builder
            .HasOne(p => p.Flavor)
            .WithOne(f => f.Product)
            .HasForeignKey<Flavor>(f => f.Id).OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(p => p.Category)
            .WithOne(c => c.Product)
            .HasForeignKey<Category>(c => c.Id).OnDelete(DeleteBehavior.NoAction);
    }
}
