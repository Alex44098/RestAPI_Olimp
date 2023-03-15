using Application.Interfaces;
using Application.Interfaces.IAnimalType;
using Application.ViewModels;
using AutoMapper;
using Models.Entitis;

namespace Application.Posts
{
    public class AddAnimalType : IAddAnimalType
    {
        private readonly IMainDbContext _mainDbContext;
        private readonly IMapper _mapper;
        public AddAnimalType(IMainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }

        public async Task<AnimalTypeViewmodel> AddAnimType(string type)
        {
            AnimalType animType = new AnimalType
            {
                id = new int(),
                type = type
            };
            await _mainDbContext.AnimalTypes.AddAsync(animType);
            await _mainDbContext.SaveChangesAsync();

            return _mapper.Map<AnimalTypeViewmodel>(animType);
        }
    }
}
