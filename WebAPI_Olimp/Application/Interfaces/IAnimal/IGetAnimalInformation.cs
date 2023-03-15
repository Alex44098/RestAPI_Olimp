using Application.ViewModels;
using System;

namespace Application.Interfaces.IAnimal
{
    public interface IGetAnimalInformation
    {
        public Task<AnimalViewmodel> GetAnimal(long id);
        public Task<List<AnimalViewmodel>> SearchAnimals(
                DateTime? startDateTime,
                DateTime? endDateTime,
                int? chipperId,
                long? chippingLocationId,
                string? lifeStatus,
                string? gender
            );
    }
}
