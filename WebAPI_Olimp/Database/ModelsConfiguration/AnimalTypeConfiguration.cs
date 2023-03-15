using Models.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelsConfiguration
{
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.HasKey(at => at.id);
            builder.HasIndex(at => at.id).IsUnique();
            builder.Property(at => at.type);
        }
    }
}
