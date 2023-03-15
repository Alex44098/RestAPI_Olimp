using Application.ViewModels;

namespace Application.Interfaces.IVisitedLocation
{
    public interface IAddAnimalVisitedLocation
    {
        public Task<AnimalVisitedLocationViewmodel> AddVisitedLocation(long animalId, long pointId);
    }
}
