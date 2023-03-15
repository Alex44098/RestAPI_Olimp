using Application.ViewModels;

namespace Application.Interfaces.IVisitedLocation
{
    public interface IGetAnimalVisitedLocation
    {
        public Task<List<AnimalVisitedLocationViewmodel>> GetLocations(
            long animalId, DateTime startDateTime, DateTime endDateTime);
    }
}
