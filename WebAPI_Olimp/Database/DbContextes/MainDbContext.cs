/*Сщздание контекста базы данных для работы с базой данных*/
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Models.Entitis;
using Database.ModelsConfiguration;

namespace Database.DbContextes
{
    public class MainDbContext : DbContext, IMainDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<LocationPoint> LocationPoints { get; set; }
        public DbSet<AnimalVisitedLocation> AnimalVisitedLocations { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LocationPointConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalVisitedLocationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
