using IceGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IceGestor.Infra.Persistence.Configurations;
public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount).HasPrecision(4,2).IsRequired();

        builder
            .HasOne(p => p.Flavor)
            .WithOne(f => f.Product)
            .HasForeignKey<Product>(p => p.IdFlavor).OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(p => p.Category)
            .WithOne(c => c.Product)
            .HasForeignKey<Product>(p => p.IdCategory).OnDelete(DeleteBehavior.NoAction);
    }
}
