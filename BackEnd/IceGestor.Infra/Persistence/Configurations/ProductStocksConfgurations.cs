using IceGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IceGestor.Infra.Persistence.Configurations;
public class ProductStocksConfgurations : IEntityTypeConfiguration<ProductStock>
{
    public void Configure(EntityTypeBuilder<ProductStock> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Quantity).IsRequired();
    }
}
