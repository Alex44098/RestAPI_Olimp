using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IVisitedLocation;
using Application.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Entitis;

namespace Application.Gets.VisitedLocatiion
{
    public class GetAnimalVisitedLocation : IGetAnimalVisitedLocation
    {
        private readonly IMainDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAnimalVisitedLocation(IMainDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<AnimalVisitedLocationViewmodel>> GetLocations(
            long animalId, DateTime startDateTime, DateTime endDateTime)
        {
            var animal = await _dbContext.Animals.Where(anm => anm.id == animalId).FirstOrDefaultAsync();
            if (animal == null) 
            {
                throw new NotFoundException(nameof(Animal), animalId.ToString());
            }
            List<AnimalVisitedLocation> visitedLocations = new List<AnimalVisitedLocation>();
            foreach (long locationId in animal.visitedLocations)
            {
                var location = await _dbContext.AnimalVisitedLocations
                    .Where(loc => loc.id == locationId)
                    .Where(loc => loc.dateTimeOfVisitLocationPoint >= startDateTime)
                    .Where(loc => loc.dateTimeOfVisitLocationPoint <= endDateTime).FirstOrDefaultAsync();
                if (location != null) visitedLocations.Add(location);
            }
            return _mapper.Map<List<AnimalVisitedLocationViewmodel>>(visitedLocations);
            //throw new NotFoundException("locationId", animalId.ToString());
        }
    }
}
