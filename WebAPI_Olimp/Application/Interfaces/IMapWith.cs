/*Интерфейс маппинга данных*/
using AutoMapper;

namespace Application.Interfaces
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
