using Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelsConfiguration
{
    public class LocationPointConfiguration : IEntityTypeConfiguration<LocationPoint>
    {
        public void Configure(EntityTypeBuilder<LocationPoint> builder) 
        {
            builder.HasKey(locp => locp.id);
            builder.HasIndex(locp => locp.id).IsUnique();
            builder.Property(locp => locp.latitude);
            builder.Property(locp => locp.longitude);
        }
    }
}
