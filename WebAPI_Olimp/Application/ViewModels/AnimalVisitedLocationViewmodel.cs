using Application.Interfaces;
using AutoMapper;
using Models.Entitis;

namespace Application.ViewModels
{
    public class AnimalVisitedLocationViewmodel : IMapWith<AnimalVisitedLocation>
    {
        public long id { get; set; }
        public long locationPointId { get; set; }
        public DateTime dateTimeOfVisitLocationPoint { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnimalVisitedLocation, AnimalVisitedLocationViewmodel>()
                .ForMember(avlvm => avlvm.id,
                option => option.MapFrom(avl => avl.id))
                .ForMember(avlvm => avlvm.locationPointId,
                option => option.MapFrom(avl => avl.locationPointId))
                .ForMember(avlvm => avlvm.dateTimeOfVisitLocationPoint,
                option => option.MapFrom(avl => avl.dateTimeOfVisitLocationPoint));
        }
    }
}
