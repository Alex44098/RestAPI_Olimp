using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entitis;
using System.Security.Cryptography.X509Certificates;

namespace Database.ModelsConfiguration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(animal => animal.id);
            builder.HasIndex(animal => animal.id).IsUnique();
            builder.Property(animal => animal.animalTypes);
            builder.Property(animal => animal.weight).HasMaxLength(7);
            builder.Property(animal => animal.lenght).HasMaxLength(7);
            builder.Property(animal => animal.height).HasMaxLength(7);
            builder.Property(animal => animal.gender).HasMaxLength(6);
            builder.Property(animal => animal.lifeStatus).HasMaxLength(5);
            builder.Property(animal => animal.chippingDateTime);
            builder.Property(animal => animal.chipperId);
            builder.Property(animal => animal.chippingLocationId);
            builder.Property(animal => animal.visitedLocations);
            builder.Property(animal => animal.deathDateTime);
        }
    }
}
