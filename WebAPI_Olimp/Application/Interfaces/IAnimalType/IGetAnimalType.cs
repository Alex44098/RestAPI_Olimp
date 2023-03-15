using Application.ViewModels;

namespace Application.Interfaces.IAnimalType
{
    public interface IGetAnimalType
    {
        public Task<AnimalTypeViewmodel> GetAnimalType(long id);
    }
}
