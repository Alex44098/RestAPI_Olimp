using Application.ViewModels;

namespace Application.Interfaces.IAnimal
{
    public interface IAddAnimalInformation
    {
        public Task<AnimalViewmodel> AddAnimal(
                long[] animalTypes,
                float weight,
                float lenght,
                float height,
                string gender,
                int chipperId,
                long chippingLocationId
            );
    }
}
