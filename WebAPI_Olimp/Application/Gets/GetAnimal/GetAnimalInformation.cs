using Application.Interfaces;
using Application.Interfaces.IAnimal;
using Application.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;
using Models.Entitis;

namespace Application.Gets.GetAnimal
{
    public class GetAnimalInformation : IGetAnimalInformation
    {
        private readonly IMainDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAnimalInformation(IMainDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AnimalViewmodel> GetAnimal(long id)
        {
            var animal = await _dbContext.Animals.Where(anim => anim.id == id).FirstOrDefaultAsync();
            if (animal == null)
            {
                throw new NotFoundException(nameof(Animal), id.ToString());
            }
            return _mapper.Map<AnimalViewmodel>(animal);
        }
        public async Task<List<AnimalViewmodel>> SearchAnimals(
            DateTime? startDateTime,
                DateTime? endDateTime,
                int? chipperId,
                long? chippingLocationId,
                string? lifeStatus,
                string? gender)
        {
            var animal = await _dbContext.Animals
                .Where(anim => startDateTime < anim.chippingDateTime && anim.chippingDateTime < endDateTime)
                .Where(anim => chipperId != null ? anim.chipperId == chipperId : true)
                .Where(anim => chippingLocationId != null ? anim.chippingLocationId == chippingLocationId : true)
                .Where(anim => lifeStatus != null ? anim.lifeStatus == lifeStatus : true)
                .Where(anim => gender != null ? anim.gender == gender : true).ToListAsync();
            if (animal.Count == 0)
            {
                throw new NotFoundException(nameof(Animal), chipperId.ToString() + " " + chippingLocationId.ToString());
            }
            return _mapper.Map<List<AnimalViewmodel>>(animal);
        }
    }
}