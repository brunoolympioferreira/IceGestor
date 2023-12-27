using IceGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IceGestor.Infra.Persistence.Configurations;
public class FlavorConfigurations : IEntityTypeConfiguration<Flavor>
{
    public void Configure(EntityTypeBuilder<Flavor> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name).HasMaxLength(50).IsRequired();
        builder.Property(f => f.Description).HasMaxLength(200);
    }
}
