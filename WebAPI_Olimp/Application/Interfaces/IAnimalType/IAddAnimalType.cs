using Application.ViewModels;

namespace Application.Interfaces.IAnimalType
{
    public interface IAddAnimalType
    {
        public Task<AnimalTypeViewmodel> AddAnimType(string type);
    }
}
