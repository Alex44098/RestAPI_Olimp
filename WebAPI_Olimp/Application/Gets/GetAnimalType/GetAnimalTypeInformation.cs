using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;
using Models.Entitis;
using Application.ViewModels;
using Application.Interfaces.IAnimalType;

namespace Application.Gets.GetAnimalType
{
    public class GetAnimalTypeInformation : IGetAnimalType
    {
        private readonly IMainDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAnimalTypeInformation(IMainDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AnimalTypeViewmodel> GetAnimalType(long id)
        {
            var animType = await _dbContext.AnimalTypes.Where(at => at.id == id).FirstOrDefaultAsync();
            if (animType == null)
            {
                throw new NotFoundException(nameof(AnimalType), id.ToString());
            }

            return _mapper.Map<AnimalTypeViewmodel>(animType);
        }
    }
}

