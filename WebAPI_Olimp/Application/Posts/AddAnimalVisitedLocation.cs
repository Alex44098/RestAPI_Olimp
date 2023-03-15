using Application.Interfaces;
using Application.Interfaces.IVisitedLocation;
using Application.ViewModels;
using Application.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Entitis;

namespace Application.Posts
{
    public class AddAnimalVisitedLocation : IAddAnimalVisitedLocation
    {
        private readonly IMainDbContext _mainDbContext;
        private readonly IMapper _mapper;
        public AddAnimalVisitedLocation(IMainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }

        public async Task<AnimalVisitedLocationViewmodel> AddVisitedLocation(long animalId, long pointId)
        {
            var animal = await _mainDbContext.Animals.Where(anm => anm.id == animalId).FirstOrDefaultAsync();
            var location = await _mainDbContext.LocationPoints.Where(loc => loc.id == pointId).FirstOrDefaultAsync();
            if (animal == null || location == null)
            {
                throw new NotFoundException("Animal or location", "not exist");
            }
            else
            {
                if (animal.lifeStatus == "DEAD" || animal.chippingLocationId == pointId)
                {
                    throw new InvalidRequestException();
                }
                else
                {
                    AnimalVisitedLocation visitedLocation = new AnimalVisitedLocation
                    {
                        id = new long(),
                        locationPointId = pointId,
                        dateTimeOfVisitLocationPoint = DateTime.Now
                    };

                    await _mainDbContext.AnimalVisitedLocations.AddAsync(visitedLocation);
                    await _mainDbContext.SaveChangesAsync();

                    if (animal.visitedLocations == null)
                    {
                        animal.visitedLocations = new long[0];
                    }
                    long[] tmp = animal.visitedLocations;
                    Array.Resize(ref tmp, tmp.Length + 1);
                    tmp[tmp.Length - 1] = visitedLocation.id;
                    animal.visitedLocations = tmp;
                    _mainDbContext.Animals.Update(animal);

                    await _mainDbContext.SaveChangesAsync();

                    return _mapper.Map<AnimalVisitedLocationViewmodel>(visitedLocation);
                }
            }
        }
    }
}
