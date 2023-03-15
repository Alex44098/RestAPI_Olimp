using Application.Interfaces;
using Application.Interfaces.IAnimal;
using Application.ViewModels;
using AutoMapper;
using Models.Entitis;

namespace Application.Posts
{
    public class AddAnimalInformation : IAddAnimalInformation
    {
        private readonly IMainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public AddAnimalInformation(IMainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }

        public async Task<AnimalViewmodel> AddAnimal(
                long[] animalTypes,
                float weight,
                float lenght,
                float height,
                string gender,
                int chipperId,
                long chippingLocationId)
        {
            Animal animal = new Animal
            {
                id = new long(),
                animalTypes = animalTypes,
                weight = weight,
                lenght = lenght,
                height = height,
                gender = gender,
                lifeStatus = "ALIVE",
                chippingDateTime = DateTime.Now,
                chipperId = chipperId,
                chippingLocationId = chippingLocationId,
                visitedLocations = new long[] { chippingLocationId },
                deathDateTime = DateTime.MinValue
            };
            await _mainDbContext.Animals.AddAsync(animal);
            await _mainDbContext.SaveChangesAsync();

            return _mapper.Map<AnimalViewmodel>(animal);
        }
    }
}
