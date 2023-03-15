/*Интерфейс контекста базы данных*/
using Microsoft.EntityFrameworkCore;
using Models.Entitis;

namespace Application.Interfaces
{
    public interface IMainDbContext
    {
        DbSet<Account> Accounts { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<LocationPoint> LocationPoints { get; set; }
        public DbSet<AnimalVisitedLocation> AnimalVisitedLocations { get; set; }
        public DbSet<Animal> Animals { get; set; }
        Task<int> SaveChangesAsync(/*CancellationToken cancellationToken*/);
    }
}
