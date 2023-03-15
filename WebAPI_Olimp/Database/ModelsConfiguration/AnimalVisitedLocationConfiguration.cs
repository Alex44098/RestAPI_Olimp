using Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelsConfiguration
{
    public class AnimalVisitedLocationConfiguration : IEntityTypeConfiguration<AnimalVisitedLocation>
    {
        public void Configure(EntityTypeBuilder<AnimalVisitedLocation> builder)
        {
            //builder.Property(avl => avl.id);
            builder.HasKey(avl => avl.id);
            builder.HasIndex(avl => avl.id).IsUnique();
            builder.Property(avl => avl.locationPointId);
            builder.Property(avl => avl.dateTimeOfVisitLocationPoint);
        }
    }
}
